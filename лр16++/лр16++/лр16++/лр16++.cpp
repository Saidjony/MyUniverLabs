#include <iostream>
#include <math.h>

using namespace std;

class konus {

private:
	double r;
	double h;

	const double PI = 3.14159265;

public:
	konus(double radius, double height) {
		r = radius;
		h = height;
	}

	double areaSide() {
		return PI * r * sqrt(r * r + h * h);
	}

	double volume() {
		return 1. / 3 * PI * r * r * h;
	}

	double secarea(double height) {
		double radius = height * r / h;
		return PI * radius * radius;
	}

	double areasecnorm(double d) {
		double height = d * h / 2;
		return height;
	}

	konus operator + (konus c) {
		konus cTemp(r + c.r, h + c.h);

		return cTemp;
	}

	bool operator > (konus c) {
		if (this -> volume() > c.volume()) {
			return true;
			cout << "Первый конус больше второго\n";
		}
		else {
			return false;
		}
	}

	konus operator - () {
		r--;
		h--;

		return *this;
	}

	void display() {
		cout << "\nРадиус = " << r;
		cout << "\nВысота = " << h << endl;
	}
};

int main()
{
	setlocale(LC_ALL, "RUS");

	double r, h;

	cout << "Введите радиус конуса: \n";
	cin >> r;

	cout << "Введите высоту конуса: \n";
	cin >> h;

	konus c1(r, h);

	cout << "\nПлощадь боковой поверхности конуса: " << c1.areaSide() << endl;

	cout << "\nОбъём конуса равен: " << c1.volume() << endl;

	cout << "\nВведите высоту на которой находится сечение, параллельное основанию конуса, \n  для нахождения его площади (меньше или равно " << h << " и больше 0): ";
	cin >> h;
	cout << "\nПлощадь сечения параллельного основанию конуса равна: " << c1.secarea(h) << endl;

	cout << "\nВведите диаметр основания сечения, перпендикулярного основанию конуса,\n  для нахождения его площади (меньше или равно " << 2 * r << " и больше 0): ";
	cin >> r;
	cout << "\nПлощадь сечения перпендикулярного основанию конуса равна: " << c1.areasecnorm(r) << endl;

	cout << "\nВведите радиус конуса: \n";
	cin >> r;

	cout << "Введите высоту конуса: \n";
	cin >> h;

	konus c2(r, h);

	cout << "\nСложение двух конусов: ";
	konus c3 = c1 + c2;
	c3.display();

	cout << "\nСравнение двух конусов (>):\n";
	if (c1 > c2) {
		cout << "Первый конус больше второго\n";
	}
	else {
		cout << "Первый конус меньше второго или равен ему\n";
	}

	- c1;
	cout << "\nДекремент первого конуса (--):";
	c1.display();

	system("pause");
	return 0;
}