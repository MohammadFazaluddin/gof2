# Game Of Life (Conway's Game of Life):

The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, live or dead. Every cell interacts with its eight neighbours, which are the cells that are directly horizontally, vertically, or diagonally adjacent. At each step in time, the following transitions occur:

1. Any live cell with fewer than two live neighbours dies, as if by loneliness.
2. Any live cell with more than three live neighbours dies, as if by overcrowding.
3. Any live cell with two or three live neighbours lives, unchanged, to the next generation.
4. Any dead cell with exactly three live neighbours comes to life.

The initial pattern constitutes the 'seed' of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed - births and deaths happen simultaneously, and the discrete moment at which this happens is sometimes called a tick. (In other words, each generation is a pure function of the one before.) The rules continue to be applied repeatedly to create further generations.

## How To

While being in the project directory run the `dotnet` command to run the project

```bash
dotnet run
```

You will be prompted to seed the initial pattern by entering the co-ordinates of the cells

First enter the number of cells that needs to be seeded

```bash
Enter the number of cells you want to seed
3
```

Then start entering the co-ordinates of the cells comma seperated format as follows

```bash
Enter cell co-ordinates
1, 0 
1, 1
1, 2
```

In the output there will be all of the Live Cells of the Next Generation

```bash
Output:
0, 1
1, 1
2, 1
```

### Complete Output

```bash
Enter the number of cells you want to seed
3

Enter cell co-ordinates
1, 0 
1, 1
1, 2

Output:
0, 1
1, 1
2, 1
```
