using System.Collections.Generic;
using System.Linq;

namespace BotCreators.DataSource
{
    public class DataContext
    {
        public List<Triplet> Triplets;

        public DataContext()
        {
            
        }

        public List<string> GetData(string Object, string predict)
        {
            return
                Triplets.Where(p => p.Object.Equals(Object)).Where(p => p.Predict.Equals(predict))
                    .Select(triplet => triplet.Subject)
                    .ToList();
        }

        public void AddData(string Object, string predict, string subject)
        {
            Triplets.Add(new Triplet
            {
                Object = Object,
                Predict = predict,
                Subject = subject
            });
        }

    }

    public class Triplet
    {
        public string Object { get; set; }
        public string Predict { get; set; }
        public string Subject { get; set; }
    }
}
