using NUR;
using System;
using System.Collections.Generic;



public class Program
{
    public static void Main(string[] args)
    {
        MemorySegmentationNUR memoryNUR = new MemorySegmentationNUR(4, 4096); // Exemplo com capacidade de 4 páginas e tamanho de página de 4096 bytes

        // Simulando referências de páginas
        memoryNUR.ReferencePage(1);
        memoryNUR.ReferencePage(2);
        memoryNUR.ReferencePage(3);
        memoryNUR.ReferencePage(4);
        memoryNUR.ReferencePage(1);
        memoryNUR.ReferencePage(2);
        memoryNUR.ReferencePage(5);

        // Exibindo o estado das páginas na memória
        Console.WriteLine("\n");
        Console.WriteLine("NUR - Estado atual das páginas na memória:\n");
        for (int i = 0; i < memoryNUR.MemoryNRU.Count; i++)
        {
            Console.WriteLine("Page: " + memoryNUR.MemoryNRU[i].PageNumber + " | Referenced: " + memoryNUR.MemoryNRU[i].Referenced + " | Modified: " + memoryNUR.MemoryNRU[i].Modified);
        }

        MemorySegmentationFIFO memoryFIFO = new MemorySegmentationFIFO(4, 4096); // Exemplo com capacidade de 4 páginas e tamanho de página de 4096 bytes

        // Simulando referências de páginas
        memoryFIFO.ReferencePage(5);
        memoryFIFO.ReferencePage(2);
        memoryFIFO.ReferencePage(3);
        memoryFIFO.ReferencePage(3);
        memoryFIFO.ReferencePage(1);
        memoryFIFO.ReferencePage(2);
        memoryFIFO.ReferencePage(5);

        // Exibindo o estado das páginas na memória
        Console.WriteLine("\n");
        Console.WriteLine("FIFO - Estado atual das páginas na memória:\n");
        for (int i = 0; i < memoryFIFO.MemoryFIFO.Count; i++)
        {
            Console.WriteLine("Page: " + memoryFIFO.MemoryFIFO[i].PageNumber + " | Referenced: " + memoryFIFO.MemoryFIFO[i].Referenced + " | Modified: " + memoryFIFO.MemoryFIFO[i].Modified);
        }


        MemorySegmentationSC memorySC = new MemorySegmentationSC(4, 4096); // Exemplo com capacidade de 4 páginas e tamanho de página de 4096 bytes

        // Simulando referências de páginas
        memorySC.ReferencePage(1);
        memorySC.ReferencePage(2);
        memorySC.ReferencePage(3);
        memorySC.ReferencePage(4);
        memorySC.ReferencePage(2);
        memorySC.ReferencePage(5);
        memorySC.ReferencePage(1);

        // Exibindo o estado das páginas na memória
        Console.WriteLine("\n");
        Console.WriteLine("SC - Estado atual das páginas na memória:\n");
        for (int i = 0; i < memorySC.MemorySC.Count; i++)
        {
            Console.WriteLine("Page: " + memorySC.MemorySC[i].PageNumber + " | Referenced: " + memorySC.MemorySC[i].Referenced + " | Modified: " + memorySC.MemorySC[i].Modified);
        }

        MemorySegmentationClock memoryClock = new MemorySegmentationClock(4, 4096); // Exemplo com capacidade de 4 páginas e tamanho de página de 4096 bytes

        // Simulando referências de páginas
        memoryClock.ReferencePage(1);
        memoryClock.ReferencePage(2);
        memoryClock.ReferencePage(3);
        memoryClock.ReferencePage(4);
        memoryClock.ReferencePage(1);
        memoryClock.ReferencePage(2);
        memoryClock.ReferencePage(5);

        // Exibindo o estado das páginas na memória
        Console.WriteLine("\n");
        Console.WriteLine("Clock - Estado atual das páginas na memória:\n");
        for (int i = 0; i < memoryClock.MemoryClock.Count; i++)
        {
            Console.WriteLine("Page: " + memoryClock.MemoryClock[i].PageNumber + " | Referenced: " + memoryClock.MemoryClock[i].Referenced + " | Modified: " + memoryNUR.MemoryNRU[i].Modified);
        }

        MemorySegmentationMRU memoryMRU = new MemorySegmentationMRU(4, 4096); // Exemplo com capacidade de 4 páginas e tamanho de página de 4096 bytes

        // Simulando referências de páginas
        memoryMRU.ReferencePage(1);
        memoryMRU.ReferencePage(2);
        memoryMRU.ReferencePage(3);
        memoryMRU.ReferencePage(4);
        memoryMRU.ReferencePage(1);
        memoryMRU.ReferencePage(2);
        memoryMRU.ReferencePage(5);

        // Exibindo o estado das páginas na memória
        Console.WriteLine("\n");
        Console.WriteLine("MRU - Estado atual das páginas na memória:\n");
       
        for (int i = 0; i < memoryMRU.MemoryMRU.Count; i++)
        {
            Console.WriteLine("Page: " + memoryMRU.MemoryMRU[i].PageNumber + " | Referenced: " + memoryMRU.MemoryMRU[i].Referenced + " | Modified: " + memoryMRU.MemoryMRU[i].Modified);
        }
    }
}
