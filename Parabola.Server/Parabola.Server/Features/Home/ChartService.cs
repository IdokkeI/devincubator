namespace Parabola.Server.Features.Home
{
    using Parabola.Server.Data;
    using Parabola.Server.Features.Home.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ChartService : IChartService
    {
        MyDataContext db = new MyDataContext();
        public async Task<UserData> AddUserData(ParaboleModel model)
        {
            var userdata = db.UserData.Add(new UserData
            {
                RangeFrom = model.RangeFrom,
                RangeTo = model.RangeTo,
                step = model.step,
                a = model.a,
                b = model.b,
                c = model.c
            });

            await db.SaveChangesAsync();

            return userdata;
        }

        public async Task<Dictionary<double, double>> Points(ParaboleModel model, UserData userdata)
        {
            Dictionary<double, double> points = new Dictionary<double, double>();

            for (int i = model.RangeFrom; i <= model.RangeTo; i += model.step)
            {
                points
                    .Add(i, model.a * Math.Pow(i, 2) + model.b * i + model.c);

                db.Points.Add(new Point
                {
                    ChartId = userdata.UserDataId,
                    PointX = i,
                    PointY = model.a * Math.Pow(i, 2) + model.b * i + model.c
                });
            }
            await db.SaveChangesAsync();

            return points;
        }
    }
}