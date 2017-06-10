using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient.BL
{
    public class AlgoProcess
    {
        public AdvancedAMA ama;
        public ICommunicator comm;
        public int commodity;
        public int algoPrice;
        public int algoAmount;
        public List<AlgoStep> algoList;

        public int RequestID;

        public IEnumerator<AlgoStep> enumerator;

        public AlgoProcess(AdvancedAMA ama, ICommunicator comm)
        {
            this.ama = ama;
            this.comm = comm;
            this.commodity = -1;
            this.algoPrice = -1;
            this.algoAmount = -1;
            this.RequestID = -1;
            this.enumerator = algoList.GetEnumerator();
        }

        public bool run()
        {
            AlgoStep current = enumerator.Current;
            if (current == null) return false;

            bool success = current.runStep(this);
            goToNextProcess(success);

            return success;
        }



        public void addAlgoStep(AlgoStep step)
        {
            algoList.Add(step);
        }
        
        
        public void goToNextProcess(bool next)
        {
            if (next)
            {
                if (!enumerator.MoveNext())
                {
                    enumerator = algoList.GetEnumerator();
                }
            }
        }
    }

    public interface AlgoStep
    {
        bool runStep(AlgoProcess list);
    }
}
