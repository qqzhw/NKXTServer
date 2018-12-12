using Abp.Application.Services.Dto;
using Abp.MultiTenancy;
using ICIMS.Authentication.JwtBearer;
using ICIMS.Authorization;
using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ICIMS.Controllers
{

    [Route("api/[controller]/[action]")]
    public class FilesManageController : ICIMSControllerBase
    {
        private readonly LogInManager _logInManager;
        private readonly ITenantCache _tenantCache;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly TokenAuthConfiguration _configuration;
        private readonly IFilesManageAppService _ifilesManageAppService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public FilesManageController(
            LogInManager logInManager,
            ITenantCache tenantCache, IHostingEnvironment hostingEnvironment,
            AbpLoginResultTypeHelper abpLoginResultTypeHelper,
            TokenAuthConfiguration configuration,
            IFilesManageAppService ifilesManageAppService)
        {
            _logInManager = logInManager;
            _tenantCache = tenantCache;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _configuration = configuration;
            _ifilesManageAppService = ifilesManageAppService;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpPost]

        public async Task<FilesManageInput> UploadFileAsync(IFormCollection formcollection, FilesManageInput model) 
        {
            if (formcollection.Files.Count>0)
            {
                var file = formcollection.Files[0];
                model.ContentType = file.ContentType; 
                model.TenantId = AbpSession.TenantId; 
                model.FileSize = file.Length;
                model.DownloadGuid = Guid.NewGuid();
                //原文件名 不包括路径
                var fileName = file.FileName;
                var index = fileName.LastIndexOf('.');
                ////获取文件扩展名
                 var fileExtensionName = Path.GetExtension(fileName);
                model.Extension = fileExtensionName;
                var NewFileName =fileName.Substring(0,index)+"_1" + fileExtensionName;
                //string[] pictureFormatArray = { ".png", ".jpg", ".jpeg", ".bmp", ".gif", ".ico", ".PNG", ".JPG", ".JPEG", ".BMP", ".GIF", ".ICO" };
                //if (!pictureFormatArray.Contains(fileExtensionName))
                //{
                //    var jsonstr = JsonConvert.SerializeObject(new { Code = 0, IsSuccess = false, Message = "文件格式不是有效的图片文件。" });

                //    return new RawJsonActionResult(jsonstr);
                //}
                var folder = _hostingEnvironment.WebRootPath + $@"\Upload\{model.EntityKey}\{DateTime.Now.Year}\{DateTime.Now.Month}\{DateTime.Now.Day}";

                if (!Directory.Exists(folder))//路径不存在则创建
                {
                    Directory.CreateDirectory(folder);
                }
                 var FilePath = Path.Combine(folder, fileName);
                if (System.IO.File.Exists(FilePath))
                {
                    model.FileName = NewFileName;
                    FilePath = Path.Combine(folder, NewFileName);
                }
                else
                {
                    model.FileName = file.FileName;
                }
                using (FileStream fs = System.IO.File.Create(FilePath))
                {
                    await file.CopyToAsync(fs);
                    fs.Flush();
                }
                model.DownloadUrl= $@"/Upload/{model.EntityKey}/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}/"+NewFileName;
                //var webUrl = $@"/Upload/CampaignFiles/" + NewFileName;// _webHelper.GetStoreLocation() + "/Upload/Pictures/" + fileName;
               return await  _ifilesManageAppService.InsertOrUpdate(model);
                //model.ImagePath = _webHelper.GetStoreLocation().TrimEnd('/') + webUrl;
            }

            return null;
        }
        [HttpGet]
        public async Task<FileContentResult> GetDownloadByGuid(string guid)
        {
            var item = await _ifilesManageAppService.GetByGuid(guid);
            if (item == null)
                return null;

            //return result
            var fileName = _hostingEnvironment.WebRootPath + item.DownloadUrl.Replace("/", "\\");// !string.IsNullOrWhiteSpace(download.Filename) ? download.Filename : product.Id.ToString();
            var contentType = !string.IsNullOrWhiteSpace(item.ContentType) ? item.ContentType : MimeTypes.ApplicationOctetStream;
            var downloadBinary = AuthGetFileData(fileName);
            return new FileContentResult(downloadBinary, contentType) { FileDownloadName = item.FileName + item.Extension };
        }
        [HttpGet]
        public async Task<FileContentResult> GetDownloadById(int Id)
        {
            var item =await _ifilesManageAppService.GetById(new EntityDto<int>(Id));
            if (item == null)
                return null; 
         
            //return result
            var fileName = _hostingEnvironment.WebRootPath + item.DownloadUrl.Replace("/", "\\");// !string.IsNullOrWhiteSpace(download.Filename) ? download.Filename : product.Id.ToString();
            var contentType = !string.IsNullOrWhiteSpace(item.ContentType) ? item.ContentType : MimeTypes.ApplicationOctetStream;
            var downloadBinary = AuthGetFileData(fileName);
              return new FileContentResult(downloadBinary, contentType) { FileDownloadName = item.FileName + item.Extension };
        }
        /// <summary>
        /// 将文件转换成byte[] 数组
        /// </summary>
        /// <param name="fileUrl">文件路径文件名称</param>
        /// <returns>byte[]</returns>
        protected byte[] AuthGetFileData(string fileUrl)
        {
            using (FileStream fs = new FileStream(fileUrl, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                byte[] buffur = new byte[fs.Length];
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(buffur);
                    bw.Close();
                }
                return buffur;
            }
        }

    }
}
