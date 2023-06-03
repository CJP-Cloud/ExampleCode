#include <iostream>
#include <iomanip>
#include <cstdlib>
#include <cmath>
#include <omp.h>
#include <mpi.h>

//NOTE CANT RUN ON HERE GIVES ERRORS
//HAVE TO RUN ON COMMAND LINE
//(probably caused by the omp)

const int SIZE = 100;


int main() {

    // create the matrix
    double** matrix = new double*[SIZE];
    for (int i = 0; i < SIZE; i++) {
        matrix[i] = new double[SIZE];
        for (int j = 0; j < SIZE; j++) {
            matrix[i][j] = 0.0;
        }
    }

    // spike the value of the leftmost edge in the middle
    matrix[0][SIZE/2] = 100000.0;
    //omp threads set to 16 for now
    omp_set_num_threads(16);
    // run the simulation (2 million at the moment)
    for(int inter = 0; inter < 2000000; inter++){

        // create a copy of the matrix to store new values
        double** newMatrix = new double*[SIZE];
        for (int i = 0; i < SIZE; i++) {
            newMatrix[i] = new double[SIZE];
            for (int j = 0; j < SIZE; j++) {
                newMatrix[i][j] = matrix[i][j];
            }
        }
        //omp stuff
        #pragma omp parallel for shared(matrix, newMatrix) 


        // This is where each cell in the matrix 
        // gets updated
        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                
                //trackers
                double sum = 0.0;
                int count = 0;

                // calculate the average of the cell's neighbours
                //so it calculates whatever is to the left, right, top, bottom, as well as all the corners
                //for loops checks from -1 to 1 on both axis
                //0 0 0 0 0
                //0 0 0 0 0 
                //0 0 1 1 0 
                //0 0 0 9 2 
                //0 0 0 1 3
                //checking the matrix location with a 9, you see everything around it 
                for (int o = -1; o <= 1; o++) {
                    for (int p = -1; p <= 1; p++) {
                        //whichever node we are looking at + or - 
                        //whatever the local for loop is on
                        int index = i + o;
                        int index2 = j + p;
                        //checks if the currently looked at index is within the bounds of the matrix
                        //and it checks with (o != 0 || o != 0) if it is in the middle, i.e the matrix being looked at
                        if (index >= 0 && index < SIZE && index2 >= 0 && index2 < SIZE && (o != 0 || p != 0)) 
                        {
                            //gets the sum + what is in the current matrix cell
                            sum += matrix[index][index2];
                            //keeps track of total
                            count++;
                        }
                    }
                }

                //check if count is greater than 0, avoids dividing by 0
                //did this because i kept getting NAN errors (caused by something else), and its a good double check
                //but i dont believe it to be necessary 
                double average;
                if(count > 0){
                    average = sum / count;
                }
                else {
                    average = 0.0;
                }
                 

                // calculate the amount to transfer to the neighbours nodes
                //the difference is 
                double difference = matrix[i][j] - average;
                double give = 0.05 * difference;

                // transfer to each neighbour
                //checks the neighbours like it did previously, but now its transfering the new values to the correct location
                for (int o = -1; o <= 1; o++) {
                    for (int p = -1; p <= 1; p++) {
                        //whichever node we are looking at + or - 
                        //whatever the local for loop is on
                        int index = i + o;
                        int index2 = j + p;
                        //checks if the currently looked at index is within the bounds of the matrix
                        //and it checks with (o != 0 || o != 0) if it is in the middle, i.e the matrix being looked at
                        if (index >= 0 && index < SIZE && index2 >= 0 && index2 < SIZE && (o != 0 || p != 0)) {
                            double give = give / count;
                            if (matrix[index][index2] > matrix[i][j]) {
                                give = std::min(give, matrix[index][index2] - matrix[i][j]);
                            }

                            //replaces values of the indeces around that current index
                            newMatrix[index][index2] += give;
                            newMatrix[i][j] -= give;
                        }
                    }
                }
                
            }
        }

        // update the original matrix with the new values
        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                matrix[i][j] = newMatrix[i][j];
            }
            delete[] newMatrix[i];
        }
        delete[] newMatrix;

    }

// print the final matrix
std::cout << std::fixed << std::setprecision(1);
double total = 0.0;
for (int i = 0; i < SIZE; i++) {
    for (int j = 0; j < SIZE; j++) {
        std::cout << matrix[i][j] << " ";
        total += matrix[i][j];

        
    }
    std::cout << std::endl;
}
std::cout << "Total: " << total << std::endl;

return 0;

}