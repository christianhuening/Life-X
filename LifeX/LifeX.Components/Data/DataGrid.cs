using System;
using LifeX.API.Data;
using LifeX.API.Environment.GeoCommon;

namespace LifeX.Components.Data
{
    public class DataGrid<T> : IDataGrid
    {
        public double GetAccumulatedPathRating(IGeoCoordinate start, IGeoCoordinate destination,
            double failFastThreshold = Double.MaxValue)
        {
            throw new NotImplementedException();
        }

        public double GetAccumulatedPathRating(IGeoCoordinate start, double speed, double bearing,
            double failFastThreshold = Double.MaxValue)
        {
            throw new NotImplementedException();
        }

        public void AddCellRating(IGeoCoordinate position, double ratingValue)
        {
            throw new NotImplementedException();
        }

        public void ReduceCellRating(IGeoCoordinate position, double ratingValue)
        {
            throw new NotImplementedException();
        }

        public void SetCellRating(IGeoCoordinate position, double cellValue)
        {
            throw new NotImplementedException();
        }

        public double TryTakeFromCell(IGeoCoordinate position, double amount)
        {
            throw new NotImplementedException();
        }

        public double GetCellRating(IGeoCoordinate position)
        {
            throw new NotImplementedException();
        }

        public IGeoCoordinate GetMaxValueNeighbourCoordinate(IGeoCoordinate position)
        {
            throw new NotImplementedException();
        }

    }
}