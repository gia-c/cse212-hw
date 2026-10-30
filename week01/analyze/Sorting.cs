public static class Sorting {
    public static void Run() {
        var numbers = new[] { 3, 2, 1, 6, 4, 9, 8 };
        SortArray(numbers);
        Console.Out.WriteLine("int[]{{{0}}}", string.Join(", ", numbers)); //int[]{1, 2, 3, 4, 6, 8, 9}
    }
    //This sorts the numbers
    private static void SortArray(int[] data) {
        for (var sortPos = data.Length - 1; sortPos >= 0; sortPos--) { // El for externo controla las pasadas del algoritmo.
            for (var swapPos = 0; swapPos < sortPos; ++swapPos) { //El for interno recorre y compara parejas de números consecutivos.
                if (data[swapPos] > data[swapPos + 1]) { // If left number is greater than the one on the right, it swaps
                    (data[swapPos + 1], data[swapPos]) = (data[swapPos], data[swapPos + 1]);
                }
            }
        }
    }
}