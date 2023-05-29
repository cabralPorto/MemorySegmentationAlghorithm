using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUR
{
    public class MemorySegmentationNUR
    {
        private List<Page> memory;
        private int pageSize;
        public List<Page> MemoryNRU => memory;

        public MemorySegmentationNUR(int capacity, int size)
        {
            memory = new List<Page>(capacity);
            pageSize = size;
            InitializeMemory();
        }

        private void InitializeMemory()
        {
            for (int i = 0; i < memory.Capacity; i++)
            {
                memory.Add(new Page { PageNumber = -1, Referenced = false, Modified = false });
            }
        }

        public void ReferencePage(int pageNumber)
        {
            int segmentIndex = FindPageInMemory(pageNumber);

            if (segmentIndex != -1)
            {
                memory[segmentIndex].Referenced = true;
            }
            else
            {
                ReplacePage(pageNumber);
            }
        }

        private int FindPageInMemory(int pageNumber)
        {
            for (int i = 0; i < memory.Count; i++)
            {
                if (memory[i].PageNumber == pageNumber)
                {
                    return i;
                }
            }
            return -1;
        }

        private void ReplacePage(int pageNumber)
        {
            int victimIndex = GetVictimPage();

            memory[victimIndex].PageNumber = pageNumber;
            memory[victimIndex].Referenced = true;
            memory[victimIndex].Modified = false;
        }

        private int GetVictimPage()
        {
            while (true)
            {
                for (int i = 0; i < memory.Count; i++)
                {
                    if (!memory[i].Referenced && !memory[i].Modified)
                    {
                        return i;
                    }
                }

                for (int i = 0; i < memory.Count; i++)
                {
                    if (!memory[i].Referenced && memory[i].Modified)
                    {
                        return i;
                    }

                    memory[i].Referenced = false;
                }
            }
        }
    }
}
