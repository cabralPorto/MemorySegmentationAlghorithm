using NUR;

public class MemorySegmentationSC
{
    private List<Page> memory;
    private int pageSize;
    private int currentIndex;
    public List<Page> MemorySC => memory; 
    public MemorySegmentationSC(int capacity, int size)
    {
        memory = new List<Page>(capacity);
        pageSize = size;
        currentIndex = 0;
        InitializeMemory();
    }

    private void InitializeMemory()
    {
        for (int i = 0; i < memory.Capacity; i++)
        {
            memory.Add(new Page { PageNumber = -1, Referenced = false, Modified = false, SecondChance = false });
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
        while (true)
        {
            if (!memory[currentIndex].Referenced)
            {
                memory[currentIndex].PageNumber = pageNumber;
                memory[currentIndex].Referenced = true;
                memory[currentIndex].Modified = false;
                memory[currentIndex].SecondChance = false;
                currentIndex = (currentIndex + 1) % memory.Count;
                break;
            }
            else
            {
                memory[currentIndex].Referenced = false;
                memory[currentIndex].SecondChance = true;
                currentIndex = (currentIndex + 1) % memory.Count;
            }
        }
    }
}