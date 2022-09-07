// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Numerics;

Console.WriteLine("Hello, World!");
List<string> chessNames = new List<string>() {"knight", "bishop", "pawn", "rook", "queen", "king" };
foreach(string chessName in chessNames)
    Console.WriteLine(Valid7DigitPhoneNumberFromKeypad.SumValidDepthCombinations(chessName));
//Valid7DigitPhoneNumberFromKeypad.SumValidDepthCombinations("bishop");
Console.Read();

public static class Valid7DigitPhoneNumberFromKeypad
{
    public static BigInteger SumValidDepthCombinations(string chessPieceName)
    {
        chessPieceName = chessPieceName.ToLower().Trim();
        BigInteger result = BigInteger.Zero;    
        IEnumerable validDigit = Enumerable.Range(2,8);
        foreach(int num in validDigit)
        {
            result += ValidDepthCombinations(chessPieceName, num);
        }
        return result;
    } 
    public static BigInteger ValidDepthCombinations(string chessPieceName, int startDigit, int depth = 1)
    {
        if (startDigit > 9)
            throw new Exception("Invalid Start Digit");
        if (depth == 1 && (startDigit == 1 || startDigit == 0))
            throw new Exception("You cannot start from 1 or 0");
        if (depth == 7)
            return 1;
        List<int> a = ChessPiecePossibleMoves(chessPieceName, startDigit);
        BigInteger totalPossibleMoves = 0;
        if (a.Count == 0)
            return 0;
        foreach (int move in a)
        {
            totalPossibleMoves += ValidDepthCombinations(chessPieceName, move, depth + 1);
        }
        return totalPossibleMoves;
    }

    public static List<int> ChessPiecePossibleMoves(string chessPeice, int index)
    {
        Dictionary<int, List<int>> bishopValidMoves = new()
        {
            [1] = new List<int> { 5, 9 },
            [2] = new List<int> { 4, 6 },
            [3] = new List<int> { 5, 7 },
            [4] = new List<int> { 2, 8 },
            [5] = new List<int> { 1, 3, 7, 9 },
            [6] = new List<int> { 2, 8 },
            [7] = new List<int> { 5, 0, 3 },
            [8] = new List<int> { 4, 6 },
            [9] = new List<int> { 5, 0, 1 },
            [0] = new List<int> { 7, 9 }
        };

        Dictionary<int, List<int>> knightValidMoves = new()
        {
            [1] = new List<int> { 6, 8 },
            [2] = new List<int> { 7, 9 },
            [3] = new List<int> { 4, 8 },
            [4] = new List<int> { 3, 9, 0 },
            [5] = new List<int>(), //no valid moves
            [6] = new List<int> { 1, 7, 0 },
            [7] = new List<int> { 2, 6 },
            [8] = new List<int> { 1, 3 },
            [9] = new List<int> { 4, 2 },
            [0] = new List<int> { 4, 6 }
        };

        Dictionary<int, List<int>> queenValidMoves = new()
        {
            [1] = new List<int> { 2, 3, 4, 5, 7, 9 },
            [2] = new List<int> { 1, 3, 4, 5, 6, 8, 0 },
            [3] = new List<int> { 1, 2, 5, 6, 7, 9 },
            [4] = new List<int> { 1, 2, 5, 6, 7, 8 },
            [5] = new List<int> { 1, 2, 3, 4, 6, 7, 8, 9, 0 },
            [6] = new List<int> { 2, 3, 4, 5, 8, 9 },
            [7] = new List<int> { 1, 3, 4, 5, 8, 9, 0 },
            [8] = new List<int> { 2, 4, 5, 6, 7, 9, 0 },
            [9] = new List<int> { 1, 3, 5, 6, 7, 8 },
            [0] = new List<int> { 2, 5, 7, 8, 9 }
        };

        Dictionary<int, List<int>> kingValidMoves = new()
        {
            [1] = new List<int> { 2, 4, 5, },
            [2] = new List<int> { 1, 3, 4, 5, 6 },
            [3] = new List<int> { 2, 5, 6 },
            [4] = new List<int> { 1, 2, 5 },
            [5] = new List<int> { 1, 2, 3, 4, 6, 7, 8, 9 },
            [6] = new List<int> { 2, 3, 5, 8, 9 },
            [7] = new List<int> { 4, 5, 8, 0 },
            [8] = new List<int> { 4, 5, 6, 7, 9, 0 },
            [9] = new List<int> { 5, 6, 8 },
            [0] = new List<int> { 7, 8, 9 }
        };

        Dictionary<int, List<int>> rookValidMoves = new()
        {
            [1] = new List<int> { 2, 3, 4, 7 },
            [2] = new List<int> { 1, 3, 5, 8, 0 },
            [3] = new List<int> { 1, 2, 6, 9 },
            [4] = new List<int> { 1, 5, 6, 7 },
            [5] = new List<int> { 2, 4, 6, 8, 0 },
            [6] = new List<int> { 3, 4, 5, 9 },
            [7] = new List<int> { 1, 4, 8, 9 },
            [8] = new List<int> { 2, 5, 7, 9, 0 },
            [9] = new List<int> { 3, 6, 7, 8 },
            [0] = new List<int> { 2, 5, 8, }
        };

        Dictionary<int, List<int>> pawnValidMoves = new()
        {
            [1] = new List<int> { 5 },
            [2] = new List<int> { 4, 6 },
            [3] = new List<int> { 5 },
            [4] = new List<int> { 8 },
            [5] = new List<int> { 7, 9 },
            [6] = new List<int> { 8 },
            [7] = new List<int> { 0 },
            [8] = new List<int>(),
            [9] = new List<int> { 0 },
            [0] = new List<int>()
        };

        Dictionary<string, Dictionary<int, List<int>>> allPieceMoves = new()
        {
            ["bishop"] = bishopValidMoves,
            ["knight"] = knightValidMoves,
            ["queen"] = queenValidMoves,
            ["king"] = kingValidMoves,
            ["rook"] = rookValidMoves,
            ["pawn"] = pawnValidMoves
        };
        return allPieceMoves[chessPeice][index];
    }
}


//var
//funt(chessPiece, startIndex, depth=0){
//if(depth = 7)
//return 0;
//int numberOfPossibleMoves = 0;
//}
//var a = return List<int> PossibleMoves(chessPeice, startIndex)
//if(length(a) > 0)
//for(a){
//numberOfPossibleMoves += funt(chessPiece, a, depth+1)
//}
//}
//else if a == 0
//return 0;
//
//return a.length * numberofpossiblemoves;