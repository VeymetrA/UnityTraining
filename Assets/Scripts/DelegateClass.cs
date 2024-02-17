using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    public class DelegateClass
    {
        public Action<int> Action;//void
        public Func<string, int> Func;//return int
        Predicate<Test> Predicate;// return true or flase

        public void Main()
        {
            Action += Method;//подписка
            Action -= Method;//отписка

            Func += Function;
            Func -= Function;

            Method(10);

            Action(10);//неправильно
            Action?.Invoke(10);//правильно
            /*
             * ?
            if(Action != null)
            {
                Action.Invoke();
            }
            //*/
        }

        public void Method(int x)
        {

        }

        public int Function(string str)
        {
            return 0;
        }

        private bool CheckTest(in Test test)
        {
            return test.number > 10;
        }

        private class Test
        {
            public int number;
        }
    }
}
