using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src
{
    public class FizzBuzz
    {
        private List<Criteria> criterias;

        public FizzBuzz(List<Criteria> criterias)
        {
            this.criterias = criterias;
        }

        public string Get(int input)
        {
            if (input < 1)
            {
                throw new ArgumentException("Input must be greater than 0");
            }
            else
            {
                return GetWithMultipleCriteria(input);
            }
        }

        public string GetWithMultipleCriteria(int input)
        {
            var criteriasInOrder = criterias.OrderByDescending(c => c.Number.Length);
            var matchingCriteria = criteriasInOrder.FirstOrDefault(criteria => criteria.Number.All(n => input % n == 0));

            return matchingCriteria?.Expected ?? input.ToString();
        }
    }
}