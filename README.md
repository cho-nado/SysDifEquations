# Solving a system of differential equations with n variables and n unknowns using the 4th order Runge-Kutta method

With this code, you can solve a system of differential equations with any number of variables and any number of unknowns using the 4th order Runge-Kutta method.

## What is that? 
The Runge-Kutta method is a numerical technique used to solve ordinary differential equations (ODEs). The 4th-order Runge-Kutta method is a common variant because it provides a good balance between accuracy and computational efficiency.

## Problem Setup:
The goal is to solve an initial value problem of the form:

<img width="256" alt="Снимок экрана 2024-10-14 в 12 58 22 AM" src="https://github.com/user-attachments/assets/e121a402-9e7e-47da-af5c-b971c8a6f67a">


The Runge-Kutta method approximates the solution by progressing step-by-step from an initial condition, using intermediate calculations to achieve higher accuracy.

## 4th-Order Runge-Kutta Formulas:

The "4th order" refers to the error reduction; the error per step is proportional to the step size raised to the 5th power, making it more accurate than lower-order methods.

For each step from t_n to t_(n+1) = t_n + h, where h is the step size, the 4th-order Runge-Kutta method calculates the following four intermediate values:

<img width="267" alt="Снимок экрана 2024-10-14 в 12 57 05 AM" src="https://github.com/user-attachments/assets/86c85df2-69c4-4354-9ebc-f72f2e88deaf">

Then, the solution is updated by combining these intermediate values:

<img width="311" alt="Снимок экрана 2024-10-14 в 12 57 31 AM" src="https://github.com/user-attachments/assets/1d4db1fb-8ba5-45f4-a198-cd9487da878c">


## How It Works: 
1. Initial Step: Start with the known initial value y(t_0) = y_0 and select a step size h.
2. First Approximation (k_1): Evaluate the slope at the initial point (t_n,y_n).
3. Second Approximation (k_2): Compute the slope at the midpoint using k_1.
4. Third Approximation (k_3): Compute the slope again at the midpoint using k_2.
5. Fourth Approximation (k_4): Compute the slope at the next time step using k_3.
6. Final Combination: The next value y_(n+1) is calculated as a weighted average of these four slopes.

## Why 4th Order?
The method is called "4th order" because the local truncation error per step is proportional to h^5, and the overall error is proportional to h^4. This provides a significant accuracy boost compared to lower-order methods, such as the Euler method (1st-order) or the midpoint method (2nd-order). It achieves this accuracy without excessively increasing the computational complexity, making it a preferred method in many practical applications.


### Advantages of the 4th-Order Runge-Kutta Method:

* **High Accuracy**: With fourth-order accuracy, it produces better results for a given step size compared to lower-order methods.
* **Stability**: The method is stable for a broad range of problems, especially in solving stiff ODEs when coupled with adaptive step sizes.
* **No Need for Higher Derivatives**: Unlike some other methods, the 4th-order Runge-Kutta only requires evaluations of the function f(t,y), not its higher derivatives.
* **Simple to Implement**: Despite the four intermediate calculations, the method is straightforward to code and apply.
