using Abp.Application.Services.Dto;
using Abp.MultiTenancy;
using Aspose.Words;
using Aspose.Words.Replacing;
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

        private async Task<IActionResult> Print()
        {
            return new JsonResult(null);
        }
        private void OnExportFlowDocumentCmd(object o)
        {
            try
            {
                var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "666.docx");

                var file1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "777.docx");
                var content = "evento";
                // Open the document.
                Document doc = new Document(file); 
                //// Replace the text in the document.
                //doc.Range.Replace("$UnitName$", "UnitName", new FindReplaceOptions(FindReplaceDirection.Forward));
                //string cmdNo = string.Format("成联指【{0}】号", 511);
                //doc.Range.Replace("$CreationTime$", PayAuditList.CreationTime.ToString("yyyy-MM-dd"), new FindReplaceOptions(FindReplaceDirection.Forward));
                //doc.Range.Replace("$ItemDefineName$", PayAuditList.ItemDefineName, new FindReplaceOptions(FindReplaceDirection.Forward));

                //doc.Range.Replace("$DefineAmount$", PayAuditList.DefineAmount.ToString(), new FindReplaceOptions(FindReplaceDirection.Forward));
                //doc.Range.Replace("$ItemDescription$", ItemDefine?.ItemDescription == null ? "" : ItemDefine?.ItemDescription, new FindReplaceOptions(FindReplaceDirection.Forward));
                //doc.Range.Replace("$FundItems$", PayAuditList.AccountName.ToString(), new FindReplaceOptions(FindReplaceDirection.Forward));

                //doc.Range.Replace("$ContractName$", PayAuditList.ContractName, new FindReplaceOptions(FindReplaceDirection.Forward));
                //doc.Range.Replace("$ContractAmount$", PayAuditList.ContractAmount.ToString(), new FindReplaceOptions(FindReplaceDirection.Forward));


                //doc.Range.Replace("$VendorName$", PayAuditList.VendorName, new FindReplaceOptions(FindReplaceDirection.Forward));
                //doc.Range.Replace("$PayDescription$", PayAudit.PayDetail, new FindReplaceOptions(FindReplaceDirection.Forward));
                //doc.Range.Replace("$PayAmount$", PayAudit.PayAmount.ToString(), new FindReplaceOptions(FindReplaceDirection.Forward));


                doc.Range.Replace("$AuditOpinion1$", "", new FindReplaceOptions(FindReplaceDirection.Forward));

                DocumentBuilder builder = new DocumentBuilder(doc);
                NodeCollection allTables = doc.GetChildNodes(NodeType.Table, true);
                builder.MoveToDocumentEnd();
                //builder.StartTable();
                Aspose.Words.Tables.Table table = allTables[0] as Aspose.Words.Tables.Table;//拿到第一个表格
                var rowCount = table.Count;
                //builder.InsertCell();
                //builder.Write("ROW1ASD");
                //builder.InsertCell();
                //builder.Write("asdsad");
                //builder.EndRow();
                //  DataTable products = this.GetData(); //数据源
                //builder.InsertCell();
                //builder.InsertCell();
                //for (int i = 0; i < 3; i++)
                //{
                //    var roww = table.Rows[rowCount-2];
                //    //var row = table.LastRow.Clone(true);
                //    var row = roww.Clone(true);//复制第三行(绿色行)
                //    table.Rows.Insert(rowCount + i, row);//将复制的行插入当前行的上方
                //    builder.MoveToCell(0, rowCount+i, 0, 0);
                //    builder.Writeln($"asdas还是审核人{i+1}");
                //    builder.MoveToCell(0, rowCount + i, 1, 0);
                //    builder.Write("$Title$" + i.ToString());
                //}
                //doc.Range.Replace("$Title$", "真的啊", new FindReplaceOptions(FindReplaceDirection.Forward));
                //builder.MoveToCell(0, 3, 0, 0); //移动到第一个表格的第四行第一个格子
                //builder.Write("test"); //单元格填充文字
                int count = 0;

                //记录要显示多少列
                //for (var i = 0; i < products.Columns.Count; i)
                //{
                //    if (doc.Range.Bookmarks[products.Columns[i].ColumnName.Trim()] != null)
                //    {
                //        Bookmark mark = doc.Range.Bookmarks[products.Columns[i].ColumnName.Trim()];
                //        mark.Text = "";
                //        count;
                //    }

                //}
                //System.Collections.Generic.List listcolumn = new System.Collections.Generic.List(count);
                //for (var i = 0; i < count; i)
                //{
                //    builder.MoveToCell(0, 0, i, 0); //移动单元格
                //    if (builder.CurrentNode.NodeType == NodeType.BookmarkStart)
                //    {
                //        listcolumn.Add((builder.CurrentNode as BookmarkStart).Name);
                //    }
                //}
                double width = builder.CellFormat.Width;//获取单元格宽度
                //builder.MoveToBookmark("table"); //开始添加值
                //for (var m = 0; m < products.Rows.Count; m)
                //{
                //    for (var i = 0; i < listcolumn.Count; i)
                //    {
                //        builder.InsertCell(); // 添加一个单元格 
                //        builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                //        builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                //        builder.CellFormat.Width = width;
                //        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                //        builder.Write(products.Rows[m][listcolumn[i]].ToString());
                //    }
                //    builder.EndRow();
                //}
                //doc.Range.Bookmarks["table"].Text = ""; // 清掉标示 
                //builder.DeleteRow(0, 5);
                // Save the modified document.
                doc.Save(file1);  
            }
            catch (Exception ex)
            {
            }
        }


    }
}
