using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Models;
using GHPRS.Core.UnitOfWork;
using GHPRS.Core.Utilities;
using GHPRS.Core.Validations;
using GHPRS.EmailService;
using Hangfire;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using OfficeOpenXml;

namespace GHPRS.Core.Services
{
    public class UploadService : IUploadService
    {
        private readonly IExcelService _excelService;
        private readonly ILogger<UploadService> _logger;
        private readonly ITemplateRepository _templateRepository;
        private readonly IUploadRepository _uploadRepository;
        private readonly IWorkSheetRepository _worksheetRepository;
        private readonly IFileUploadRepository _fileUploadRepository;
        private readonly IMerDataRepository _merDataRepository;
        private readonly IFacilityDataRepository _facilityDataRepository;
        private readonly ICommunityDataRepository _communityDataRepository;
        private readonly IEmailSender _emailSender;

        public UploadService(IUploadRepository uploadRepository, 
            ITemplateRepository templateRepository,
            ILogger<UploadService> logger, 
            IWorkSheetRepository workSheetRepository, 
            IExcelService excelService,
            IFileUploadRepository fileUploadRepository,
            IMerDataRepository merDataRepository,
            IFacilityDataRepository facilityDataRepository,
            ICommunityDataRepository communityDataRepository,
            IEmailSender emailSender)
        {
            _uploadRepository = uploadRepository;
            _templateRepository = templateRepository;
            _worksheetRepository = workSheetRepository;
            _excelService = excelService;
            _logger = logger;
            _fileUploadRepository = fileUploadRepository;
            _merDataRepository = merDataRepository;
            _facilityDataRepository = facilityDataRepository;
            _communityDataRepository = communityDataRepository;
            _emailSender = emailSender;
        }

        public void InsertUploadData(int uploadId)
        {
            int errors = 0;
            var upload = _uploadRepository.GetFullUploadById(uploadId);
            var worksheets = _worksheetRepository.GetFullWorkSheetsByTemplateId(upload.Template.Id);
            foreach (var worksheet in worksheets)
            {
                var range = worksheet.Range;
                var startIndex = range.IndexOf(":", StringComparison.Ordinal);
                var startAddress = range.Substring(0, startIndex);
                var rowColumn = Utility.ExcelRowAndColumn(startAddress);
                var memoryStream = new MemoryStream(upload.File);
                try
                {
                    //read uploaded data
                    var data = _excelService.ReadExcelWorkSheet(memoryStream, worksheet.Name, rowColumn.Item1,
                        rowColumn.Item2);

                    //remove all rows with columns containing either nothing or white space
                    var rows = data.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull
                        || string.CompareOrdinal(((string) field).Trim(), string.Empty) == 0));
                    var dataRows = rows.ToList();
                    if (dataRows.Count > 0)
                        data = dataRows.CopyToDataTable();
                    else
                        data.Rows.Clear();

                    var columns = worksheet.Columns;
                    var dataColumns = data.Columns;
                    List<string> stringColumnName = new List<string>();
                    foreach (var column in columns)
                    {
                        if (!dataColumns.Contains(column.Name))
                        {
                            stringColumnName.Add(column.Name);
                        }
                    }

                    string stringVals = String.Empty;
                    foreach (var ColName in stringColumnName)
                    {
                        stringVals += "<li>" + ColName + "</li>";
                    }

                    if (stringColumnName.Count > 0)
                    {
                        errors = 1;
                        _uploadRepository.UpdateUploadStatus(uploadId, "Failed - Missing Columns " + string.Join(",", stringColumnName));
                        
                        // send email to user that template has been processed successfully
                        var emailAddresses = new List<EmailAddress>();
                        emailAddresses.Add(new EmailAddress()
                        {
                            Address = upload.User.Email,
                            DisplayName = upload.User.Person.Name
                        });
                        var emailbody = EmailTemplates.RequiredColumnsNotFound(upload.User.Person.Name, upload.Name, stringVals);
                        var message = new Message(emailAddresses, "Data Portal - Missing Column Names", emailbody);
                        _emailSender.SendEmail(message);
                    }
                    else
                    {
                        if (data.Rows.Count > 0 && worksheet.Name != "TB")
                            _uploadRepository.InsertToTable(worksheet, data, upload.UploadBatch, upload.UploadBatchGuid);
                    }
                }
                catch (Exception e)
                {
                    _uploadRepository.UpdateUploadStatus(uploadId, $"Failed - {e.Message}");
                    _logger.LogError(e.Message, e);
                    errors = 2;
                    // send email to user that template has been processed successfully
                    var emailAddresses = new List<EmailAddress>();
                    emailAddresses.Add(new EmailAddress()
                    {
                        Address = upload.User.Email,
                        DisplayName = upload.User.Person.Name
                    });
                    var emailbody = EmailTemplates.ErrorOccurredProcessingTemplate(upload.User.Person.Name, upload.Name);
                    var message = new Message(emailAddresses, "Data Portal - Error Processing Template", emailbody);
                    _emailSender.SendEmail(message);
                }
            }

            if (errors == 0)
            {
                // set the upload has been processed to prevent re-processing
                _uploadRepository.UpdateUploadStatus(uploadId, "Successful");
                // send email to user that template has been processed successfully
                var emailAddresses = new List<EmailAddress>();
                emailAddresses.Add(new EmailAddress()
                {
                    Address = upload.User.Email,
                    DisplayName = upload.User.Person.Name
                });
                var emailbody = EmailTemplates.SuccessfullyUploadedData(upload.User.Person.Name, upload.Name);
                var message = new Message(emailAddresses, $"Data Portal - {upload.Name} Successfully Processed", emailbody);
                _emailSender.SendEmail(message);
            }
        }

        public List<object> ReadUploadData(int uploadId)
        {
            var result = new List<object>();
            var upload = _uploadRepository.GetFullUploadById(uploadId);
            if (upload == null)
            {
                return new List<object>();
            }
            var worksheets = _worksheetRepository.GetFullWorkSheetsByTemplateId(upload.Template.Id);
            foreach (var worksheet in worksheets)
            {
                var range = worksheet.Range;
                var startIndex = range.IndexOf(":", StringComparison.Ordinal);
                var startAddress = range.Substring(0, startIndex);
                var rowColumn = Utility.ExcelRowAndColumn(startAddress);
                var memoryStream = new MemoryStream(upload.File);
                try
                {
                    //read uploaded data
                    var data = _excelService.ReadExcelWorkSheet(memoryStream, worksheet.Name, rowColumn.Item1,
                        rowColumn.Item2);

                    //remove all rows with columns containing either nothing or white space
                    var rows = data.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull
                        || string.CompareOrdinal(((string) field).Trim(), string.Empty) == 0));
                    var dataRows = rows.ToList();
                    if (dataRows.Count > 0) data = dataRows.CopyToDataTable();

                    var resultData = new
                    {
                        WorkSheet = worksheet.Name,
                        Data = data
                    };
                    result.Add(resultData);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message, e);
                    throw;
                }
            }

            return result;
        }

        public async Task<Upload> Upload(UploadModel upload, User user, int organizationId)
        {
            try
            {
                // fileName to save
                var template = _templateRepository.GetById(upload.TemplateId);

                //overwrite if existing and still pending and similar period
                var existing = _uploadRepository.GetFullUploads().SingleOrDefault(x =>
                    x.Name == template.Name && x.Status == UploadStatus.Pending && x.User.Id == user.Id && x.StartDate == upload.StartDate && x.EndDate == upload.EndDate);
                if (existing != null) _uploadRepository.Delete(existing.Id);

                var initializedUpload = new Upload
                {
                    Name = template.Name,
                    FileExtension = template.FileExtension,
                    ContentType = upload.File.ContentType,
                    Status = UploadStatus.Pending,
                    StartDate = upload.StartDate,
                    EndDate = upload.EndDate,
                    User = user,
                    Template = template,
                    UploadBatchGuid = Guid.NewGuid(),
                    OrganizationId = organizationId
                };
                initializedUpload.GenerateUploadBatch();

                await using (var target = new MemoryStream())
                {
                    await upload.File.CopyToAsync(target);
                    initializedUpload.File = target.ToArray();
                }

                initializedUpload.UploadStatus = "Pending";
                var result = _uploadRepository.Insert(initializedUpload);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
            
        }

        public async Task<FileUploads> UploadMER(MERUploadModel merUploadModel, User user)
        {
            try
            {
                var merData = new FileUploads
                {
                    Name = merUploadModel.File.FileName,
                    ContentType = merUploadModel.File.ContentType,
                    User = user,
                    UploadDate = DateTime.Now,
                    Status = "Processing",
                    UploadType = "MER Data"
                };
                await using (var target = new MemoryStream())
                {
                    await merUploadModel.File.CopyToAsync(target);
                    merData.File = target.ToArray();
                }
                var result = _fileUploadRepository.Insert(merData);
                BackgroundJob.Enqueue<IUploadService>(x => x.InsertMerData());
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<FileUploads> UploadFacilityData(MERUploadModel merUploadModel, User user)
        {
            try
            {
                var facilityData = new FileUploads()
                {
                    Name = merUploadModel.File.FileName,
                    ContentType = merUploadModel.File.ContentType,
                    User = user,
                    UploadDate = DateTime.Now,
                    Status = "Processing",
                    UploadType = "Facility Data"
                };
                await using (var target = new MemoryStream())
                {
                    await merUploadModel.File.CopyToAsync(target);
                    facilityData.File = target.ToArray();
                }

                var result = _fileUploadRepository.Insert(facilityData);
                BackgroundJob.Enqueue<IUploadService>(x => x.InsertFacilityData());
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Review(Upload upload, Review review)
        {
            try
            {
                // change status to overWritten if existing and approved
                var overWrite = _uploadRepository.GetFullUploads().FirstOrDefault(x =>
                    x.UploadBatch == upload.UploadBatch && x.Status == UploadStatus.Approved);

                upload.Status = (UploadStatus)review.Status;
                upload.Comments = review.Comments;

                _uploadRepository.Update(upload);


                // Extract data from approved templates
                if ((UploadStatus)review.Status == UploadStatus.Approved)
                    BackgroundJob.Enqueue<IUploadService>(x => x.InsertUploadData(upload.Id));
                    
                // Overwrite after insert of previous data
                if (overWrite != null) BackgroundJob.Enqueue<IUploadService>(x => x.OverWriteApproved(overWrite.Id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw e;
            }
        }

        public void OverWriteApproved(int uploadId)
        {
            var overWrite = _uploadRepository.GetFullUploadById(uploadId);
            _uploadRepository.UpdateStatus(overWrite.Id, UploadStatus.OverWritten);
            var workSheets = _worksheetRepository.GetFullWorkSheetsByTemplateId(overWrite.Template.Id);
            foreach (var workSheet in workSheets)
            {
                if (workSheet.Name == "Facility Data")
                {
                    _uploadRepository.DeleteFromTable("StagingFacilityData", overWrite.UploadBatch, overWrite.UploadBatchGuid);
                }
                else if (workSheet.Name == "Community Data")
                {
                    _uploadRepository.DeleteFromTable("StagingCommunityData", overWrite.UploadBatch, overWrite.UploadBatchGuid);
                }
                else if (workSheet.Name == "TB")
                {
                    _uploadRepository.DeleteFromTable("StagingTBData", overWrite.UploadBatch, overWrite.UploadBatchGuid);
                }
                else
                {
                    _uploadRepository.DeleteFromTable(workSheet.TableName, overWrite.UploadBatch, overWrite.UploadBatchGuid);
                }
            }
        }

        public async void InsertMerData()
        {
            var pendingUpload = _fileUploadRepository.GetPendingUploads("MER Data");
            bool errorOccured = false;
            try
            {
                DataTable datatable = new DataTable();
                char[] delimiter = new char[] { '\t' };
                List<MerData> merData = new List<MerData>();
                if (pendingUpload != null)
                {
                    using (var reader = new StreamReader(new MemoryStream(pendingUpload.File)))
                    {
                        string[] columnheaders = reader.ReadLine().Split(delimiter);
                        foreach (string columnheader in columnheaders)
                        {
                            datatable.Columns.Add(columnheader); // I've added the column headers here.
                        }

                        while (reader.Peek() >= 0)
                        {
                            DataRow datarow = datatable.NewRow();
                            datarow.ItemArray = reader.ReadLine().Split(delimiter);
                            datatable.Rows.Add(datarow);
                        }
                    }

                    pendingUpload.Status = "Completed";
                    _fileUploadRepository.UpdateFile(pendingUpload);

                    string json = JsonConvert.SerializeObject(datatable, Formatting.Indented);
                    var deserializedData = JsonConvert.DeserializeObject<MerData[]>(json);
                    merData.AddRange(deserializedData.ToList());
                    merData.ForEach(z => z.FileUploadsId = pendingUpload.Id);
                    if (merData.Any())
                    {
                        _merDataRepository.Insert(merData);
                    }
                }
            }
            catch (Exception e)
            {
                errorOccured = true;
                _logger.LogError(e.Message, e);
                if (pendingUpload != null)
                {
                    pendingUpload.Status = $"Error - {e.Message}";
                    _fileUploadRepository.UpdateFile(pendingUpload);
                            
                    // send email to user that template has been processed successfully
                    var emailAddresses = new List<EmailAddress>();
                    emailAddresses.Add(new EmailAddress()
                    {
                        Address = pendingUpload.User.Email,
                        DisplayName = pendingUpload.User.Person.Name
                    });
                    var emailbody = EmailTemplates.ErrorOccurredProcessingTemplate(pendingUpload.User.Person.Name, pendingUpload.Name);
                    var message = new Message(emailAddresses, "Data Portal - Error MER Data", emailbody);
                    _emailSender.SendEmail(message);
                }
            }
            finally
            {
                if (pendingUpload != null && !errorOccured)
                {
                    pendingUpload.Status = "Completed";
                    _fileUploadRepository.UpdateFile(pendingUpload);
                            
                    // send email to user that template has been processed successfully
                    var emailAddresses = new List<EmailAddress>();
                    emailAddresses.Add(new EmailAddress()
                    {
                        Address = pendingUpload.User.Email,
                        DisplayName = pendingUpload.User.Person.Name
                    });
                    var emailbody = EmailTemplates.SuccessfullyUploadedMerData(pendingUpload.User.Person.Name, pendingUpload.Name);
                    var message = new Message(emailAddresses, "Data Portal - MER Data Processed", emailbody);
                    _emailSender.SendEmail(message);
                }
            }
        }
        
        public void InsertFacilityData()
        {
            var pendingUpload = _fileUploadRepository.GetPendingUploads("Facility Data");
            bool errorOccured = false;
            try
            {
                if (pendingUpload != null)
                {
                    var emailAddresses = new List<EmailAddress>();
                    emailAddresses.Add(new EmailAddress()
                    {
                        Address = pendingUpload.User.Email,
                        DisplayName = pendingUpload.User.Person.Name
                    });
                    
                    using (var memoryStream = new MemoryStream(pendingUpload.File))
                    {
                        using var excelPack = new ExcelPackage();
                        //Load excel stream
                        excelPack.Load(memoryStream);

                        //select worksheet
                        var worksheet = excelPack.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Facility Data");
                        var communityExcelWorksheet =
                            excelPack.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Community Data");
                        //Validate worksheet
                        if (worksheet != null)
                        {
                            var excelAsTable = ReadExcelWorkSheet(worksheet);
                            //validate data from excel
                            JSchemaGenerator generator = new JSchemaGenerator();
                            JSchema schema = generator.Generate(typeof(FacilityDataValidation));

                            string json = JsonConvert.SerializeObject(excelAsTable, Formatting.Indented);
                            JArray dArrays = JArray.Parse(json);
                            IList<string> messages;
                            string errors = string.Empty;
                            foreach (var dArray in dArrays)
                            {
                                bool valid = dArray.IsValid(schema, out messages);
                                if (!valid)
                                {
                                    foreach (var message in messages)
                                    {
                                        var newMessage = string.Empty;
                                        int indexOfSteam = message.IndexOf("line");
                                        if(indexOfSteam >= 0)
                                            newMessage = message.Remove(indexOfSteam);
                                        errors += "<font color='orange'><li>" + newMessage + "</li></font>";
                                    }
                                    break;
                                }
                            }

                            if (errors.Length > 0)
                            {
                                var emailbody = EmailTemplates.GetEmailTemplateListErrors(pendingUpload.User.Person.Name, pendingUpload.Name, errors);
                                var message = new Message(emailAddresses, "Data Portal - Facility Data Validation Warning",
                                    emailbody);
                                _emailSender.SendEmail(message);
                            }

                            var deserializedData = JsonConvert.DeserializeObject<FacilityData[]>(json);
                            List<FacilityData> facilityData = new List<FacilityData>();
                            facilityData.AddRange(deserializedData.ToList());
                            if (facilityData.Any())
                            {
                                _facilityDataRepository.Insert(facilityData);
                            }
                        }
                        else
                        {
                            // Facility Data not provided
                            pendingUpload.Status = "Error - Missing Facility Data Worksheet";
                            _fileUploadRepository.UpdateFile(pendingUpload);
                            
                            var emailbody = EmailTemplates.GetEmailTemplateNotFound(pendingUpload.User.Person.Name);
                            var message = new Message(emailAddresses, "Data Portal - Missing Facility Data Worksheet",
                                emailbody);
                            _emailSender.SendEmail(message);
                        }

                        if (communityExcelWorksheet != null)
                        {
                            var excelAsTable = ReadExcelWorkSheet(communityExcelWorksheet);
                            //validate data from excel
                            //validate data from excel
                            JSchemaGenerator generator = new JSchemaGenerator();
                            JSchema schema = generator.Generate(typeof(CommunityDataValidations));

                            string json = JsonConvert.SerializeObject(excelAsTable, Formatting.Indented);
                            JArray dArrays = JArray.Parse(json);
                            IList<string> messages;
                            string errors = string.Empty;
                            foreach (var dArray in dArrays)
                            {
                                bool valid = dArray.IsValid(schema, out messages);
                                if (!valid)
                                {
                                    foreach (var message in messages)
                                    {
                                        var newMessage = string.Empty;
                                        int indexOfSteam = message.IndexOf("line");
                                        if(indexOfSteam >= 0)
                                            newMessage = message.Remove(indexOfSteam);
                                        errors += "<font color='orange'><li>" + newMessage + "</li></font>";
                                    }
                                    break;
                                }
                            }

                            if (errors.Length > 0)
                            {
                                var emailbody = EmailTemplates.GetEmailTemplateListErrors(pendingUpload.User.Person.Name, pendingUpload.Name, errors);
                                var message = new Message(emailAddresses, "Data Portal - Community Data Validation Warning",
                                    emailbody);
                                _emailSender.SendEmail(message);
                            }

                            var deserializedData = JsonConvert.DeserializeObject<CommunityData[]>(json);
                            List<CommunityData> communityData = new List<CommunityData>();
                            communityData.AddRange(deserializedData.ToList());
                            if (communityData.Any())
                            {
                                _communityDataRepository.Insert(communityData);
                            }
                        }
                        else
                        {
                            pendingUpload.Status = "Error - Missing Community Data Worksheet";
                            _fileUploadRepository.UpdateFile(pendingUpload);

                            // Facility Data not provided
                            var emailbody = EmailTemplates.GetEmailTemplateNotFound(pendingUpload.User.Person.Name);
                            var message = new Message(emailAddresses, "Data Portal - Missing Community Data Worksheet",
                                emailbody);
                            _emailSender.SendEmail(message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // send email with exception
                errorOccured = true;
                _logger.LogError(e.Message, e);
                if (pendingUpload != null)
                {
                    // send email to user that template has been processed successfully
                    var emailAddresses = new List<EmailAddress>();
                    emailAddresses.Add(new EmailAddress()
                    {
                        Address = pendingUpload.User.Email,
                        DisplayName = pendingUpload.User.Person.Name
                    });
                    var emailbody = EmailTemplates.ErrorOccurredProcessingTemplate(pendingUpload.User.Person.Name, pendingUpload.Name);
                    var message = new Message(emailAddresses, "Data Portal - Error Processing Excel", emailbody);
                    _emailSender.SendEmail(message);
                    
                    pendingUpload.Status = $"Error - {e.Message}";
                    pendingUpload.User = pendingUpload.User;
                    _fileUploadRepository.UpdateFile(pendingUpload);
                }
            }
            finally
            {
                if (pendingUpload != null && !errorOccured)
                {
                    pendingUpload.Status = "Completed";
                    _fileUploadRepository.UpdateFile(pendingUpload);
                            
                    // send email to user that template has been processed successfully
                    var emailAddresses = new List<EmailAddress>();
                    emailAddresses.Add(new EmailAddress()
                    {
                        Address = pendingUpload.User.Email,
                        DisplayName = pendingUpload.User.Person.Name
                    });
                    var emailbody = EmailTemplates.SuccessfullyUploadedData(pendingUpload.User.Person.Name, pendingUpload.Name);
                    var message = new Message(emailAddresses, "Data Portal - Excel sheet Successfully Processed", emailbody);
                    _emailSender.SendEmail(message);
                }
            }
        }

        private DataTable ReadExcelWorkSheet(ExcelWorksheet worksheet)
        {
            var excelAsTable = new DataTable();
            foreach (var firstRowCell in worksheet.Cells[5, 1, 5,
                         worksheet.Dimension.End.Column])
                //Get column details
                if (!string.IsNullOrEmpty(firstRowCell.Text))
                    excelAsTable.Columns.Add(firstRowCell.Text);

            //Get row details
            for (var rowNum = 6; rowNum <= worksheet.Dimension.End.Row; rowNum++)
            {
                var wsRow = worksheet.Cells[rowNum, 1, rowNum, excelAsTable.Columns.Count];
                var row = excelAsTable.Rows.Add();
                foreach (var cell in wsRow) row[cell.Start.Column - 1] = cell.Text;
                var rowHasEmptyValuesOnly = true;
                foreach (var item in row.ItemArray)
                {
                    if (item != DBNull.Value && !string.IsNullOrWhiteSpace(item.ToString()))
                    {
                        rowHasEmptyValuesOnly = false;
                        break;
                    }
                }

                if (rowHasEmptyValuesOnly)
                {
                    excelAsTable.Rows.RemoveAt(excelAsTable.Rows.Count - 1);
                }
            }
            
            return excelAsTable;
        }
    }
}