
public class LevelMaps
{
    public static Dictionary<int, Dictionary<int, List<int>>> Mapping = new Dictionary<int, Dictionary<int, List<int>>>()
    {
        // Level 1 - Circle
        { 1, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 42, 43, 44, 45 } },
                { 1, new List<int>() { 38, 39, 40, 41 } },
                { 2, new List<int>() { 36, 37 } },
                { 3, new List<int>() { 34, 35 } },
                { 4, new List<int>() { 31, 32, 33 } },
                { 5, new List<int>() { 29, 30 } },
                { 6, new List<int>() { 25, 26, 27, 28 } },
                { 7, new List<int>() { 21, 22, 23, 24 } },
                { 8, new List<int>() { 17, 18, 19, 20 } },
                { 9, new List<int>() { 13, 14, 15, 16 } },
                { 10, new List<int>() { 8, 9, 10, 11, 12 } },
                { 11, new List<int>() { 5, 6, 7 } },
                { 12, new List<int>() { 1, 2, 3, 4 } },
                { 13, new List<int>() { 0, 54, 55 } },
                { 14, new List<int>() { 50, 51, 52, 53 } },
                { 15, new List<int>() { 46, 47, 48, 49 } },
            }
        },

        // Level 2 - Square
        { 2, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 42, 43, 44, 45} },
                { 1, new List<int>() { 39, 40, 41 } },
                { 2, new List<int>() { 36, 37, 38 } },
                { 3, new List<int>() { 33, 34, 35 } },
                { 4, new List<int>() { 31, 32, 33 } },
                { 5, new List<int>() { 29, 28, 30 } },
                { 6, new List<int>() { 25, 26, 27, 28 } },
                { 7, new List<int>() { 20, 21, 22, 23, 24 } },
                { 8, new List<int>() { 16, 17, 18, 19 } },
                { 9, new List<int>() { 11, 12, 13, 14, 15 } },
                { 10, new List<int>() { 8, 9, 10 } },
                { 11, new List<int>() { 4, 5, 6, 7 } },
                { 12, new List<int>() { 1, 2, 3, 4 } },
                { 13, new List<int>() { 55, 0, 1 } },
                { 14, new List<int>() { 51, 52, 53, 54, 55 } },
                { 15, new List<int>() { 46, 47, 48, 49, 50 } },
            }
        },

        // Level 3 - Plus
        { 3, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 41, 42, 43, 44, 45 } },
                { 1, new List<int>() { 38, 39, 40, 41 } },
                { 2, new List<int>() { 36, 37 } },
                { 3, new List<int>() { 33, 34, 35 } },
                { 4, new List<int>() { 31, 32, 33 } },
                { 5, new List<int>() { 29, 30 } },
                { 6, new List<int>() { 25, 26, 27, 28 } },
                { 7, new List<int>() { 20, 21, 22, 23, 24, 25 } },
                { 8, new List<int>() { 16, 17, 18, 19, 20 } },
                { 9, new List<int>() { 15 } },
                { 10, new List<int>() { 8, 9, 10, 11, 12, 13, 14 } },
                { 11, new List<int>() { 4, 5, 6, 7, 8 } },
                { 12, new List<int>() { 0, 1, 2, 3, 4 } },
                { 13, new List<int>() { 0, 52, 53, 54, 55 } },
                { 14, new List<int>() { 51 } },
                { 15, new List<int>() { 46, 47, 48, 49, 50 } },
            }
        },

        // Level 4 - Goggles
        { 4, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 41, 42, 43, 44, 45 } },
                { 1, new List<int>() { 37, 38, 39, 40, 41 } },
                { 2, new List<int>() { 35, 36, 37 } },
                { 3, new List<int>() { 32, 33, 34 } },
                { 4, new List<int>() { 29, 30, 31, 32 } },
                { 5, new List<int>() { 25, 26, 27, 28, 29 } },
                { 6, new List<int>() { 21, 22, 23, 24 } },
                { 7, new List<int>() { 18, 19, 20 } },
                { 8, new List<int>() { 15, 16, 17 } },
                { 9, new List<int>() { 11, 12, 13, 14 } },
                { 10, new List<int>() { 9, 10, 11 } },
                { 11, new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 } },
                { 12, new List<int>() { 0, 55, 54 } },
                { 13, new List<int>() { 52, 53, 54 } },
                { 14, new List<int>() { 49, 50, 51 } },
                { 15, new List<int>() { 45, 46, 47, 48 } },
            }
        },

        // Level 5 - Curved Plus
        { 5, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 39, 40, 41, 42, 43 } },
                { 1, new List<int>() { 35, 36, 37, 38 } },
                { 2, new List<int>() { 34, 35 } },
                { 3, new List<int>() { 32, 33, 34 } },
                { 4, new List<int>() { 31, 32 } },
                { 5, new List<int>() { 27, 28, 29, 30 } },
                { 6, new List<int>() { 22, 23, 24, 25, 26, 27 } },
                { 7, new List<int>() { 19, 20, 21, 22 } },
                { 8, new List<int>() { 17, 18, 19 } },
                { 9, new List<int>() { 11, 12, 13, 14, 15, 16, 17, 18 } },
                { 10, new List<int>() { 6, 7, 8, 9, 10 } },
                { 11, new List<int>() { 3, 4, 5 } },
                { 12, new List<int>() { 55, 0, 1, 2 } },
                { 13, new List<int>() { 48, 49, 50, 51, 52, 53, 54 } },
                { 14, new List<int>() { 47, 48, 49 } },
                { 15, new List<int>() { 43, 44, 45, 46, 47 } },
            }
        },

        // Level 6 - Triangle
        { 6, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 46, 47, 48, 49, 50, 51 } },
                { 1, new List<int>() { 38, 39, 40, 41, 42, 43, 44, 45, 46 } },
                { 2, new List<int>() { 35, 36, 37, 38 } },
                { 3, new List<int>() { 33, 34, 35 } },
                { 4, new List<int>() { 31, 32, 33 } },
                { 5, new List<int>() { 28, 29, 30, 31} },
                { 6, new List<int>() { 20, 21, 22, 23, 24, 25, 26, 27 } },
                { 7, new List<int>() { 15, 16, 17, 18, 19, 20 } },
                { 8, new List<int>() { 12, 13, 14 } },
                { 9, new List<int>() { 9, 10, 11 } },
                { 10, new List<int>() { 7, 8, 9, 10 } },
                { 11, new List<int>() { 4, 5, 6, 7 } },
                { 12, new List<int>() { 2, 3, 4 } },
                { 13, new List<int>() { 0, 1 } },
                { 14, new List<int>() { 54, 55 } },
                { 15, new List<int>() { 51, 52, 53, 54 } },
            }
        },

        // Level 7 - X
        { 7, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 39, 40, 41, 42, 43, 44 } },
                { 1, new List<int>() { 35, 36, 37, 38, 39 } },
                { 2, new List<int>() { 33, 34 } },
                { 3, new List<int>() { 32, 33 } },
                { 4, new List<int>() { 27, 28, 29, 30, 31 } },
                { 5, new List<int>() { 22, 23, 24, 25, 26, 27 } },
                { 6, new List<int>() { 20, 21, 22 } },
                { 7, new List<int>() { 16, 17, 18, 19, 20 } },
                { 8, new List<int>() { 11, 12, 13, 14, 15, 16 } },
                { 9, new List<int>() { 6, 7, 8, 9, 10 } },
                { 10, new List<int>() { 4, 5, 6 } },
                { 11, new List<int>() { 2, 3, 4 } },
                { 12, new List<int>() { 55, 0, 1, 2 } },
                { 13, new List<int>() { 50, 51, 52, 53, 54, 55 } },
                { 14, new List<int>() { 45, 46, 47, 48, 49 } },
                { 15, new List<int>() { 44, 45 } },
            }
        },

        // Level 8 - V
        { 8, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 22, 23, 24 } },
                { 1, new List<int>() { 20, 21, 22 } },
                { 2, new List<int>() { 16, 17, 18, 19 } },
                { 3, new List<int>() { 11, 12, 13, 14, 15 } },
                { 4, new List<int>() { 8, 9, 10 } },
                { 5, new List<int>() { 6, 7 } },
                { 6, new List<int>() { 5 } },
                { 7, new List<int>() { 4 } },
                { 8, new List<int>() { 3 } },
                { 9, new List<int>() { 1, 2} },
                { 10, new List<int>() { 0, 55 } },
                { 11, new List<int>() { 51, 52, 53, 54, 55 } },
                { 12, new List<int>() { 47, 48, 49, 50 } },
                { 13, new List<int>() { 44, 45, 46 } },
                { 14, new List<int>() { 41, 42, 43 } },
                { 15, new List<int>() {} },
            }
        },

        // Level 9 - Stepped V
        { 9, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 18, 19, 20 } },
                { 1, new List<int>() { 16, 17 } },
                { 2, new List<int>() { 13, 14, 15 } },
                { 3, new List<int>() { 9, 10, 11, 12 } },
                { 4, new List<int>() { 8, 9 } },
                { 5, new List<int>() { 6, 7 } },
                { 6, new List<int>() { 5 } },
                { 7, new List<int>() { 3, 4, 5 } },
                { 8, new List<int>() { 3 } },
                { 9, new List<int>() { 1, 2 } },
                { 10, new List<int>() { 0 } },
                { 11, new List<int>() { 54, 55, 0 } },
                { 12, new List<int>() { 51, 52, 53 } },
                { 13, new List<int>() { 49, 50 } },
                { 14, new List<int>() { 46, 47, 48 } },
                { 15, new List<int>() {} },
            }
        },

        // Level 10 - U
        { 10, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 26, 27 } },
                { 1, new List<int>() { 23, 24, 25 } },
                { 2, new List<int>() { 20, 21, 22 } },
                { 3, new List<int>() { 17, 18, 19 } },
                { 4, new List<int>() { 13, 14, 15, 16 } },
                { 5, new List<int>() { 9, 10, 11, 12, 13 } },
                { 6, new List<int>() { 6, 7, 8, 9 } },
                { 7, new List<int>() { 3, 4, 5 } },
                { 8, new List<int>() { 0, 1, 2 } },
                { 9, new List<int>() { 53, 54, 55, 0 } },
                { 10, new List<int>() { 50, 51, 52 } },
                { 11, new List<int>() { 47, 48, 49 } },
                { 12, new List<int>() { 44, 45, 46 } },
                { 13, new List<int>() { 41, 42, 43 } },
                { 14, new List<int>() { 39, 40 } },
                { 15, new List<int>() {} },
            }
        },

        // Level 11 - Horizontal line
        { 11, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 13, 14 } },
                { 1, new List<int>() { 12, 13 } },
                { 2, new List<int>() { 10, 11 } },
                { 3, new List<int>() { 9, 10 } },
                { 4, new List<int>() { 8, 9 } },
                { 5, new List<int>() { 6, 7 } },
                { 6, new List<int>() { 5, 6 } },
                { 7, new List<int>() { 3, 4 } },
                { 8, new List<int>() { 2, 3 } },
                { 9, new List<int>() { 1, 2 } },
                { 10, new List<int>() { 0, 1 } },
                { 11, new List<int>() { 0 } },
                { 12, new List<int>() { 44, 45 } },
                { 13, new List<int>() { 53, 54 } },
                { 14, new List<int>() { 51, 52 } },
                { 15, new List<int>() {} },
            }
        },

        // Level 12 - Heart
        { 12, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 35, 36, 37 } },
                { 1, new List<int>() { 34 } },
                { 2, new List<int>() { 33 } },
                { 3, new List<int>() { 33 } },
                { 4, new List<int>() { 32 } },
                { 5, new List<int>() { 29, 30, 31 } },
                { 6, new List<int>() { 26, 27, 28, 29 } },
                { 7, new List<int>() { 22, 23, 24, 25 } },
                { 8, new List<int>() { 18, 19, 20, 21 } },
                { 9, new List<int>() { 14, 15, 16, 17 } },
                { 10, new List<int>() { 5, 6, 7, 8, 9, 10, 11, 12, 13 } },
                { 11, new List<int>() { 53, 54, 55, 0, 1, 2, 3 } },
                { 12, new List<int>() { 49, 50, 51, 52 } },
                { 13, new List<int>() { 45, 46, 47, 48 } },
                { 14, new List<int>() { 40, 41, 42, 43, 44 } },
                { 15, new List<int>() { 37, 38, 39, 40 } },
            }
        },

        // Level 13 - Starburst
        { 13, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 33, 34, 35 } },
                { 1, new List<int>() { 31, 32, 33 } },
                { 2, new List<int>() { 28, 29, 30 } },
                { 3, new List<int>() { 23, 24, 25, 26, 27, 28 } },
                { 4, new List<int>() { 20, 21, 22 } },
                { 5, new List<int>() { 15, 16, 17, 18, 19 } },
                { 6, new List<int>() { 13, 14 } },
                { 7, new List<int>() { 7, 8, 9, 10, 11, 12 } },
                { 8, new List<int>() { 4, 5, 6 } },
                { 9, new List<int>() { 2, 3, 4 } },
                { 10, new List<int>() { 54, 55, 0, 1 } },
                { 11, new List<int>() { 51, 52, 53 } },
                { 12, new List<int>() { 47, 48, 49, 50, 51 } },
                { 13, new List<int>() { 43, 44, 45, 46 } },
                { 14, new List<int>() { 38, 39, 40, 41, 42 } },
                { 15, new List<int>() { 36, 37, 38 } },
            }
        },

        // Level 14 - W
        { 14, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 16, 17 } },
                { 1, new List<int>() { 14, 15 } },
                { 2, new List<int>() { 11, 12, 13 } },
                { 3, new List<int>() { 9, 10, 11 } },
                { 4, new List<int>() { 7, 8 } },
                { 5, new List<int>() { 6 } },
                { 6, new List<int>() { 5 } },
                { 7, new List<int>() { 3, 4, 5 } },
                { 8, new List<int>() { 3 } },
                { 9, new List<int>() { 2 } },
                { 10, new List<int>() { 0, 1 } },
                { 11, new List<int>() { 0, 55 } },
                { 12, new List<int>() { 53, 54, 55 } },
                { 13, new List<int>() { 51, 52, 53 } },
                { 14, new List<int>() { 49, 50 } },
                { 15, new List<int>() {} },
            }
        },

        // Level 15 - Inverse mountain
        { 15, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 22, 23 } },
                { 1, new List<int>() { 19, 20, 21 } },
                { 2, new List<int>() { 15, 16, 17, 18 } },
                { 3, new List<int>() { 11, 12, 13, 14, 15 } },
                { 4, new List<int>() { 8, 9, 10 } },
                { 5, new List<int>() { 7, 8 } },
                { 6, new List<int>() { 5, 6 } },
                { 7, new List<int>() { 3, 4 } },
                { 8, new List<int>() { 2, 3 } },
                { 9, new List<int>() { 0, 1 } },
                { 10, new List<int>() { 51, 52, 53, 54, 55 } },
                { 11, new List<int>() { 50, 51 } },
                { 12, new List<int>() { 47, 48, 49 } },
                { 13, new List<int>() { 44, 45, 46 } },
                { 14, new List<int>() { 42, 43 } },
                { 15, new List<int>() {} },
            }
        },

        // Level 16 - Infinity
        { 16, new Dictionary<int, List<int>>()
            {
                { 0, new List<int>() { 31, 32, 33 } },
                { 1, new List<int>() { 27, 28, 29, 30 } },
                { 2, new List<int>() { 23, 24, 25, 26, 27 } },
                { 3, new List<int>() { 18, 19, 20, 21, 22 } },
                { 4, new List<int>() { 15, 16, 17, 18 } },
                { 5, new List<int>() { 10, 11, 12, 13, 14 } },
                { 6, new List<int>() { 7, 8, 9, 10 } },
                { 7, new List<int>() { 4, 5, 6 } },
                { 8, new List<int>() { 2, 3, 4 } },
                { 9, new List<int>() { 55, 0, 1, 2} },
                { 10, new List<int>() { 52, 53, 54 } },
                { 11, new List<int>() { 48, 49, 50, 51 } },
                { 12, new List<int>() { 44, 45, 46, 47 } },
                { 13, new List<int>() { 39, 40, 41, 42, 43 } },
                { 14, new List<int>() { 36, 37, 38, 39 } },
                { 15, new List<int>() { 33, 34, 35 } },
            }
        },
    };
}