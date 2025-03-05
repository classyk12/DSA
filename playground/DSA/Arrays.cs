using System.Collections;

class Array
{
    private int[] items;
    private int count;
    public Array(int Length)
    {
        items = new int[Length];
    }

    //!CORRECT BY SOLUTION
    //!dont use array.lenght because the .Length method points to the number of spaces allocated to the array memory whether or not it has items in it
    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(items[i]);
        }
    }

    public void Insert(int value)
    {
        //if array is full, resize the array
        if (items.Length == count)
        {
            //? create a new array, twice the size of the original array
            var newItems = new int[count * 2];
            //? copy all the existing items into the array
            //   items.CopyTo(newItems, 0);
            //!alternative methods
            for (int i = 0; i < count; i++)
            {
                newItems[i] = items[i];
            }
            //? set the items to the new array
            items = newItems;
        }
        //? insert the new value into the end of the array
        items[count] = value;
        count++;
    }

    public int IndexOf(int value)
    {
        int index = -1;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == value)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public void RemoveAt(int index)
    {
        //check if the index is valid..i.e the index is within the range of the array
        if (index < 0 || index >= count)
            throw new InvalidOperationException();
        //using the index, shift the items to the left to fill the hole
        for (int i = index; i < count; i++)
        {
            items[i] = items[i + 1];
        }
        //since an item is removed, shrink the array to reflect the current size
        count--;
    }

    public void Remove(int value)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i] == value)
            {
                //copy and shift the value starting from the index of the value
                for (int n = i; i < count; i++)
                {
                    items[i] = items[i + 1];
                }
                count--;
                break;
            }
        }
    }
}