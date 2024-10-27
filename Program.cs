//*****************************************************************************
//** 1277. Count Square Submatrices with All Ones    leetcode                **
//*****************************************************************************


int countSquares(int** matrix, int matrixSize, int* matrixColSize) 
{
    int m = matrixSize, n = matrixColSize[0];
    int counter = 0;

    // Create a 2D dp array
    int** dp = (int**)malloc(m * sizeof(int*));
    for (int i = 0; i < m; i++)
        dp[i] = (int*)calloc(n, sizeof(int));

    // Initialize the first column of dp with matrix values
    for (int i = 0; i < m; i++)
        dp[i][0] = matrix[i][0];
    
    // Initialize the first row of dp with matrix values
    for (int i = 0; i < n; i++)
        dp[0][i] = matrix[0][i];

    // Fill the dp array
    for (int i = 1; i < m; i++) 
    {
        for (int j = 1; j < n; j++) 
        {
            if (matrix[i][j] == 0)
                dp[i][j] = 0;
            else
                dp[i][j] = 1 + (dp[i - 1][j] < dp[i - 1][j - 1] 
                               ? (dp[i - 1][j] < dp[i][j - 1] 
                                  ? dp[i - 1][j] 
                                  : dp[i][j - 1]) 
                               : (dp[i - 1][j - 1] < dp[i][j - 1] 
                                  ? dp[i - 1][j - 1] 
                                  : dp[i][j - 1]));
        }
    }

    // Sum up the counts of squares
    for (int i = 0; i < m; i++) 
    {
        for (int j = 0; j < n; j++)
            counter += dp[i][j];
    }

    // Free the dp array
    for (int i = 0; i < m; i++)
        free(dp[i]);
    free(dp);

    return counter;
}