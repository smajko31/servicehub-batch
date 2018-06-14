using System.Collections.Generic;
using System.Linq;

namespace ServiceHub.Batch.Library
{
    public static class ModelMapper
    {
        /// <summary>
        /// Converts a list of context Batch models to a list of libary Batch models
        /// </summary>
        /// <param name="ctxList">Context Batch model list</param>
        /// <returns>Library Batch model list</returns>
        public static List<Library.Models.Batch> ToLibraryList(List<Context.Models.Batch> ctxList)
        {
            List<Library.Models.Batch> libList = new List<Library.Models.Batch>();
            foreach (var batch in ctxList)
            {
                Library.Models.Batch libBatchModel = new Library.Models.Batch();
                libBatchModel = ToLibraryBatchModel(batch);
                if (libBatchModel == null) { return null; }
                libList.Add(libBatchModel);
            }

            return libList;
        }

        /// <summary>
        /// Converts Context batch model into Library batch model
        /// </summary>
        /// <param name="batchContext">Batch context model</param>
        /// <returns>Batch library model</returns>
        public static Library.Models.Batch ToLibraryBatchModel(Context.Models.Batch batchContext)
        {
            Library.Models.Batch batchLibrary = new Library.Models.Batch();
            batchLibrary.BatchId = batchContext.BatchId;
            batchLibrary.StartDate = batchContext.StartDate;
            batchLibrary.EndDate = batchContext.EndDate;
            batchLibrary.BatchName = batchContext.BatchName;
            batchLibrary.BatchOccupancy = batchContext.BatchOccupancy;
            batchLibrary.BatchSkill = batchContext.BatchSkill;
            batchLibrary.Address = ToLibraryAddressModel(batchContext.Address);
            batchLibrary.UserIds = batchContext.UserIds;

            if (!batchLibrary.Validate()) { return null; }
            return batchLibrary;
        }

        /// <summary>
        /// Converts Library batch model into Context batch model
        /// </summary>
        /// <param name="batchLibrary">Batch library model</param>
        /// <returns>Batch context model</returns>
        public static Context.Models.Batch ToContextBatchModel(Library.Models.Batch batchLibrary)
        {
            if (!batchLibrary.Validate()) { return null; }

            Context.Models.Batch batchContext = new Context.Models.Batch();
            batchContext.BatchId = batchLibrary.BatchId;
            batchContext.StartDate = batchLibrary.StartDate;
            batchContext.EndDate = batchLibrary.EndDate;
            batchContext.BatchName = batchLibrary.BatchName;
            batchContext.BatchOccupancy = batchLibrary.BatchOccupancy;
            batchContext.BatchSkill = batchLibrary.BatchSkill;
            batchContext.Address = ToContextAddressModel(batchLibrary.Address);
            batchContext.UserIds = batchLibrary.UserIds;

            return batchContext;
        }

        /// <summary>
        /// Converts Context address model into Library address model
        /// </summary>
        /// <param name="addressContext">Address context model</param>
        /// <returns>Address library model</returns>
        public static Library.Models.Address ToLibraryAddressModel(Context.Models.Address addressContext)
        {
            Library.Models.Address addressLibrary = new Library.Models.Address();
            addressLibrary.AddressId = addressContext.AddressId;
            addressLibrary.Address1 = addressContext.Address1;
            addressLibrary.Address2 = addressContext.Address2;
            addressLibrary.City = addressContext.City;
            addressLibrary.State = addressContext.State;
            addressLibrary.PostalCode = addressContext.PostalCode;
            addressLibrary.Country = addressContext.Country;

            if (!addressLibrary.Validate()) { return null; }
            return addressLibrary;
        }

        /// <summary>
        /// Converts Library address model into Context address model
        /// </summary>
        /// <param name="addressLibrary">Address library model</param>
        /// <returns>Address context model</returns>
        public static Context.Models.Address ToContextAddressModel(Library.Models.Address addressLibrary)
        {
            if (!addressLibrary.Validate()) { return null; }

            Context.Models.Address addressContext = new Context.Models.Address();
            addressContext.AddressId = addressLibrary.AddressId;
            addressContext.Address1 = addressLibrary.Address1;
            addressContext.Address2 = addressLibrary.Address2;
            addressContext.City = addressLibrary.City;
            addressContext.State = addressLibrary.State;
            addressContext.PostalCode = addressLibrary.PostalCode;
            addressContext.Country = addressLibrary.Country;

            return addressContext;
        }
    }
}