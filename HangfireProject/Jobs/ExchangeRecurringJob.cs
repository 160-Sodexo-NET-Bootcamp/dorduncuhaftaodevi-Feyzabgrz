using Data.UnitOfWork;
using Entities.DataModel;
using Hangfire;
using System;
using System.Linq;

namespace HangfireProject.Jobs
{
    public class ExchangeRecurringJob
    {
        private IUnitOfWork unitOfWork;
        public ExchangeRecurringJob(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }


        /* SENARYO*/

        /* Her 15 dakikada bir borsa hisse  güncel fiyatlarını tabloya insert atacak bir job yazılmıştır */
        // Controllerda bulunan RunJobs metodu tetiklendiğinde varolan joblar çalışmaya başlayacaktır


        public void StartAddJob()
        {
            var allData = unitOfWork.Exchange.GetAll();
            var lastData = allData.Result.Data.ToList().OrderByDescending(x => x.DateCreated).FirstOrDefault();
            double newInstantPrice = 0;
            if (lastData != null)
            {
                //Hisse  değerinin en faz %10 artış veya azalış gösteeceği düşünülerek hesaplama yapıldı
                var percentInstantPrice = lastData.InstantPrice * 0.1;

                //Hisse  değerinin random olarak atanabilmesi için belirli değer aralığında randım sayı üreten metot yazıldı
                newInstantPrice = GetDoubleRandom(-percentInstantPrice, percentInstantPrice) + lastData.InstantPrice;
            }
            else
            {
                //Hisse değeri default olarak belirlenmiştir.
                newInstantPrice = 3.17;
            }

            //Örn verileri bu şekilde olan bir hisse 15 dakikada bir fiyat güncelleyecek şekilde tabloya insert atıldı

            Exchange percentModel = new Exchange()
            {
                PercentName = "Eregli Demir Çelik",
                PercentCode = "EREGL",
                InstantPrice = newInstantPrice,
                Status = false,
                DateCreated = DateTime.Now
            };
            unitOfWork.Exchange.Add(percentModel);
            unitOfWork.Complete();
        }

        //Her gün saat 18:00 da çalışarak 8:00 ile 18:00 saatleri arasında eklenmiş olan verilerin status değerini değiştiren job
        public void StartDailyJob()
        {

            
            var allData = unitOfWork.Exchange.Where(x => x.DateCreated.Day == DateTime.Now.Day && x.DateCreated.Hour >= 8 && x.DateCreated.Hour <= 18).ToList();

            foreach (var item in allData)
            {
                item.Status = true;
                unitOfWork.Exchange.Update(item);

            }
            unitOfWork.Complete();

        }

        public static double GetDoubleRandom(double minValue,double maxValue)
        {
            Random random = new Random();
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
