using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public interface IStudyBehaviour
    {
        void Study();
    }
    public class StudyAtUniversity: IStudyBehaviour
    {
        public void Study()
        {
            Console.WriteLine(" is studiyng at university...");
        }
    }
    public class SelfStudy: IStudyBehaviour
    {
        public void Study()
        {
            Console.WriteLine(" is self-studying...");
        }
    }
    public class CantStudy: IStudyBehaviour
    {
        public void Study()
        {
            Console.WriteLine(" can't study!");
        }
    }
}
