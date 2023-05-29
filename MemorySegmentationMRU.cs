public class MemorySegmentationMRU
{
    private List<Page> memory;
    private int pageSize;
    public List<Page> MemoryMRU => memory;

    public MemorySegmentationMRU(int capacity, int size)
    {
        memory = new List<Page>(capacity);
        pageSize = size;
        InitializeMemory();
    }

    private void InitializeMemory()
    {
        for (int i = 0; i < memory.Capacity; i++)
        {
            memory.Add(new Page{ PageNumber = -1, Referenced = false, Modified = false });
        }
    }

    public void ReferencePage(int pageNumber)
    {
        int segmentIndex = FindPageInMemory(pageNumber);

        if (segmentIndex != -1)
        {
            memory[segmentIndex].Referenced = true;
            memory[segmentIndex].LastReferencedTime = DateTime.Now;
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
        int mruIndex = -1;
        DateTime lastReferencedTime = DateTime.MinValue;

        for (int i = 0; i < memory.Count; i++)
        {
            if (memory[i].PageNumber == -1)
            {
                mruIndex = i;
                break;
            }

            if (memory[i].LastReferencedTime > lastReferencedTime)
            {
                mruIndex = i;
                lastReferencedTime = memory[i].LastReferencedTime;
            }
        }

        if (mruIndex != -1)
        {
            memory[mruIndex].PageNumber = pageNumber;
            memory[mruIndex].Referenced = true;
            memory[mruIndex].Modified = false;
            memory[mruIndex].LastReferencedTime = DateTime.Now;
        }
    }
}

