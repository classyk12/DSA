//!DATA STRUCTURE AND ALGORITHM

#region Big O Notation
//1. Data structure refers to how data is stored in memory in a computer system
//2. Big O Notation refers to the performance of an algorithm takes to run in an event of larger/infinit input. Can also be referred to as the scalability of an algorithm

//! O(1) => (Constant) In this complexity, the size of the input doesnt affect the performance of the algorithm. You can identify a n(1) algorithm by any of the following attribute.
//- Assignment of values to variables
//- Access first element of an array
//- Access last element of an array
//- Arithmetic operations
//?e.g Console.Writeline(Array[0]) //access first element of an array

//! O(n) => (Linear), in this complexity, the size of the input affects the performance of the algorithm. You can identify a n(1) algorithm by any of the following attribute.
//- Has a loop (for, foreach, do while, while) and iterates over an item for n number of times

// e.g while(int i = 0 ; i < Array.Length; i++){
//     Console.Writeline(i);
// }

//! O(n ^ 2) => (Quadratic), in this complexity, the size of the input also affects the performance of the algorithm. You can identity a O(n^2) algorithm by any of the following attribute.
//- Has a nested loop

// e.g while (int i = 0; i < Array.Length; i++){
//     foreach (var item in AnotherArray.Length)
//     {
//         Console.Writeline($"{i} - {item}")
//     }
// }

//! O(Log n) => (Logarithmic), this performance is much faster than Quadratic and Linear complexities. You can identity a O(Log n) algorithm by any of the following attribute.
//! This operation reduces work by half in every step which makes it faster than Linear and Quadratic algorithms
//! The logarithmic curve slows down as the input size grows

// e.g Given a sorted Array, [1,2,3,4,5,6,7,8,9], Find the highest number in the array
//using Logarithmic complexity will be doing a binary search on the given array. This is done by breaking the array in halves and comparing the two sides.
//More context exist in the Binary Search Section

//! O(2^n) => (Exponential), this performance is much slower than n(Log n). It is not scalable at all and its the opposite of the O(Log n)

//! SPACE COMPLEXITY: This is the amount of space allocated in memory for our algorithm to run.

//e.g void Greet(string[] names){
//foreach(var name in names){
//Console.Writeline($"Hello {name}");
//}
//}

//? The space complexity of the above algorithm is O(n) because the space needed grows relative to the size of the input

#endregion

#region Arrays
//1. Array element each take 8 bits in c#
//2. 
#endregion

#region LinkedList

#endregion