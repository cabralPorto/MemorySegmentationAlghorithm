using NUR;

public class MemorySegmentationFIFO
{
    private List<Page> memory;
    private int pageSize;
    private Queue<Page> pageQueue;
    public List<Page> MemoryFIFO => memory;

    public MemorySegmentationFIFO(int capacity, int size)
    {
        memory = new List<Page>(capacity);
        pageSize = size;
        pageQueue = new Queue<Page>(capacity);
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
        if (pageQueue.Count == memory.Count)
        {
            Page victimPage = pageQueue.Dequeue();
            int victimIndex = memory.IndexOf(victimPage);

            memory[victimIndex].PageNumber = pageNumber;
            memory[victimIndex].Referenced = true;
            memory[victimIndex].Modified = false;

            pageQueue.Enqueue(memory[victimIndex]);
        }
        else
        {
            int emptyIndex = memory.FindIndex(p => p.PageNumber == -1);

            memory[emptyIndex].PageNumber = pageNumber;
            memory[emptyIndex].Referenced = true;
            memory[emptyIndex].Modified = false;

            pageQueue.Enqueue(memory[emptyIndex]);
        }
    }
}