﻿namespace AutoLend.Data.Repositories.Model {
    public interface IModelRepository {
        Task<DataModels.Model.Model?> GetByModelNameAsync( string modelName );

    }
}
