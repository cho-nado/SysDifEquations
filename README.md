# Solving a system of differential equations with n variables and n unknowns using the 4th order Runge-Kutta method

With this code, you can solve a system of differential equations with any number of variables and any number of unknowns using the 4th order Runge-Kutta method.

## What is that? 
The Runge-Kutta method is a numerical technique used to solve ordinary differential equations (ODEs). The 4th-order Runge-Kutta method is a common variant because it provides a good balance between accuracy and computational efficiency.

## Problem Setup:
The goal is to solve an initial value problem of the form:
\frac{dy}{dt} = f(t, y), \quad y(t_0) = y_0

The Runge-Kutta method approximates the solution by progressing step-by-step from an initial condition, using intermediate calculations to achieve higher accuracy.

## 4th-Order Runge-Kutta Formulas:

The "4th order" refers to the error reduction; the error per step is proportional to the step size raised to the 5th power, making it more accurate than lower-order methods.

For each step from t_n to t_(n+1) = t_n + h, where h is the step size, the 4th-order Runge-Kutta method calculates the following four intermediate values:
k_1 = h f(t_n, y_n)
k_2 = h f\left(t_n + \frac{h}{2}, y_n + \frac{k_1}{2}\right)
k_3 = h f\left(t_n + \frac{h}{2}, y_n + \frac{k_2}{2}\right)
k_4 = h f(t_n + h, y_n + k_3)

Then, the solution is updated by combining these intermediate values:
y_{n+1} = y_n + \frac{1}{6}(k_1 + 2k_2 + 2k_3 + k_4)

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
