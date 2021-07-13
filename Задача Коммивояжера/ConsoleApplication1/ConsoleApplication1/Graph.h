// ГРУППА: РИС-19-1б
// ФИО: МАЗИТОВ ТИМУР ЭМИЛЕВИЧ
// ВАРИАНТ 17.
// ТВОРЧЕСКОЕ ЗАДАНИЕ ЧАСТЬ 1:ЗАДАЧА КОММИВОЯЖЕРА

#pragma once
#include <vector>
#include <iostream>
#include <conio.h>
#include <string>
using namespace std;

int WinH = 700;
int WinW = 700;
int R = 30;

struct vertCoord
{
	int x, y;
};
vertCoord vertC[20];

template <class T>
class Graph {
private:
	int SIZE;
	int maxSize;
	bool IS_INIT = true;
	bool IS_LABELS = false;
	bool IS_COM_SOLVED = false;
	int* visitedVerts;
	vector<int> vertList;
	vector<int> labelList;
	vector<int> infotext;
	int vertListSize;
	T** adjMatrix;
	T** temp_COM_adjMatrix;
	T** temp1_COM_adjMatrix;
	T** temp2_COM_adjMatrix;
	T array[20];
	vertCoord sel;
	vector <bool> Visited;
	vector <int> Path;

public:
	void InitVariables();
	void set_size(int x) {SIZE = x;}
	int getlist() { return vertList[0]; }
	Graph();
	~Graph();
	int GetVertPos(const T& vertex);
	bool IsEmpty();
	bool IsFull();
	int GetAmountVerts();
	int GetAmountEdges();
	int GetWeight(const T& vertex1, const T& vertex2);
	void InsertVertex(const T& vertex);
	void InsertEdge(const T& vertex1, const T& vertex2, int weight);
	void Print();
	void InitLabels();
	void FillLabels(T& startVertex);
	bool AllVisited(int* visitedVerts);
	int D_method(T& startVertex);
	void drawVertex(int n);
	vector<T> GetNbrs(const T& vertex);
	void DrawGraph();

	// ОБРАБОТКА ДЕЙСТВИЙ МЫШИ
	void find(int, int);
	void move(int, int);
	

	// ЗАДАЧА КОММИВОЯЖЕРА
	bool hamilton(int);
	int zero_mark(int i, int j);
	int COM_rows_columns(T**);	
	void temp_COM_Print();
	int Commute_problem();
};

template<class T>
vector<T> Graph<T>::GetNbrs(const T& vertex) {
	vector<T> nbrsList; // создание списка соседей
	int pos = this->GetVertPos(vertex); /* вычисление позиции vertex в матрице смежности */
	if (pos != (-1)) { /* проверка, что vertex есть в матрице смежности */
		for (int i = 0, vertListSize = this->vertList.size(); i < vertListSize; ++i) {
			if (this->adjMatrix[pos][i] != 0) /* вычисление соседей*/
				nbrsList.push_back(this->vertList[i]); /* запись соседей в вектор */
		}
	}
	return nbrsList; // возврат списка соседей
}

template<class T>
void Graph<T>::InitVariables() {

	maxSize = 20;
	for (int i = 0; i < SIZE; i++) infotext.push_back(0);
	visitedVerts = new int[100];
	for (int i = 0; i < SIZE; i++) visitedVerts[i] = 0;
	adjMatrix = new T * [maxSize];
	for (int i = 0; i < maxSize; ++i) {
		adjMatrix[i] = new int[maxSize];
	}
	for (int i = 0; i < maxSize; ++i) {
		for (int j = 0; j < maxSize; ++j) {
			this->adjMatrix[i][j] = 0;
		}
	}
	Visited.resize(SIZE);
}

template<class T>
Graph<T>::Graph() { 
	
	
}

template<class T>
Graph<T>::~Graph() {

}

template <class T>
int Graph<T>::GetVertPos(const T& vertex) {
	for (int i = 0; i < this->vertList.size(); ++i) {
		if (this->vertList[i] == vertex)
			return i;
	}
	return -1;
}

template<class T>
bool Graph<T>::IsEmpty() {
	if (this->vertList.size() != 0)
		return false;
	else
		return true;
}

template<class T>
bool Graph<T>::IsFull() {
	return (vertList.size() == maxSize);
}

template<class T>
int Graph<T>::GetAmountVerts() {
	return this->vertList.size();
}

template<class T>
int Graph<T>::GetAmountEdges() {
	int amount = 0; // обнуляем счетчик
	if (!this->IsEmpty()) { // проверяем, что граф не пуст
		for (int i = 0, vertListSize = this->vertList.size(); i < vertListSize; ++i) {
			for (int j = 0; j < vertListSize; ++j) {
				if (this->adjMatrix[i][j] == 1) // находим рёбра
					amount += 1; // считаем количество рёбер
			}
		}
		return amount; // возвращаем количество рёбер
	}
	else
		return 0; // если граф пуст, возвращаем 0
}

template<class T>
int Graph<T>::GetWeight(const T& vertex1, const T& vertex2) {
	if (!this->IsEmpty()) {
		int vertPos1 = GetVertPos(vertex1);
		int vertPos2 = GetVertPos(vertex2);
		return adjMatrix[vertPos1][vertPos2];
	}
	return 0;
}

template<class T>
void Graph<T>::InsertVertex(const T& vertex) {
	if (!this->IsFull()) {
		this->vertList.push_back(vertex);
	}
	else {
		cout << "Граф уже заполнен. Невозможно добавить новую вершину " << endl;
		return;
	}
}

template<class T>
void Graph<T>::InsertEdge(const T& vertex1, const T& vertex2, int weight) {
	if (this->GetVertPos(vertex1) != (-1) && this->GetVertPos(vertex2) != (-1)) {
		int vertPos1 = GetVertPos(vertex1);
		int vertPos2 = GetVertPos(vertex2);
		if (this->adjMatrix[vertPos1][vertPos2] != 0) {
			cout << "Ребро между этими вершинами уже существует" << endl;
			return;
		}
		else {
			this->adjMatrix[vertPos1][vertPos2] = weight;
		}
	}
	else {
		cout << "Обеих вершин (или одной из них) нет в графе " << endl;
		return;
	}
}

template<class T>
void Graph<T>::Print() {
	if (!this->IsEmpty()) {
		cout << "Матрица смежности графа: " << endl;
		for (int i = 0, vertListSize = this->vertList.size(); i < vertListSize; ++i) {

			cout << (this->vertList[i]) << " ";
			for (int j = 0; j < vertListSize; ++j) {
				cout << " " << this->adjMatrix[i][j] << " ";
			}
			cout << endl;
		}
	}
	else {
		cout << "Граф пуст " << endl;
	}
}

void setCoord(int i, int n)
{
	int R_;
	int x0 = WinW / 2;
	int y0 = WinH / 2;
	if (WinW > WinH)
	{
		R_ = WinH / 2 - R - 100;
	}
	else {
		R_ = WinW / 2 - R - 100;
	}
	float theta = 2.0f * 3.1415926f * float(i) / float(n);
	float y1 = R_ * cos(theta) + y0;
	float x1 = R_ * sin(theta) + x0;

	vertC[i].x = x1;
	vertC[i].y = y1;
}

void drawCircle(int x, int y, int R_, bool flag2, float r,float g, float b) //рисуем круг в заданных координатах
{

	if (flag2) glColor3ub(r, g, b);
	else glColor3f(1.0,1.0,1.0);
	float x1, y1;
	glBegin(GL_POLYGON);
	for (int i = 0; i < 360; i++)
	{
		float theta = 2.0f * 3.1415926f * float(i) / float(360);
		y1 = R_ * cos(theta) + y;
		x1 = R_ * sin(theta) + x;
		glVertex2f(x1, y1);
	}
	glEnd();

	glColor3f(0.0f, 0.0f, 0.0f);
	float x2, y2;
	glBegin(GL_LINE_LOOP);
	for (int i = 0; i < 360; i++)
	{
		float theta = 2.0f * 3.1415926f * float(i) / float(360);
		y2 = R_ * cos(theta) + y;
		x2 = R_ * sin(theta) + x;
		glVertex2f(x2, y2);
	}
	glEnd();
}

void drawText(int nom, int x1, int y1, bool flag,bool flag2,int red, int green ,int blue)
{
	GLvoid* font;
	if (flag) { drawCircle(x1, y1, R / 1.3, flag2, red, green, blue); font = GLUT_BITMAP_HELVETICA_18;
	}
	else font = GLUT_BITMAP_TIMES_ROMAN_24;
	string s = to_string(nom);
	glRasterPos2i(x1 - 5, y1 - 5);
	for (int j = 0; j < s.length(); j++) {
		glutBitmapCharacter(font, s[j]);
	}
}

template <class T>
void Graph<T>::drawVertex(int n)
{
	for (int i = 0; i < n; i++) {
		if (IS_LABELS) {
			if (labelList[i] == 0) drawCircle(vertC[i].x, vertC[i].y,R,false, 0, 0.5, 0);
			else drawCircle(vertC[i].x, vertC[i].y, R,false, 1.0, 1.0, 1.0);
		}
		else drawCircle(vertC[i].x, vertC[i].y, R,false, 1.0, 1.0, 1.0);
		drawText(i + 1, vertC[i].x, vertC[i].y, false,false,1.0,1.0,1.0);
	}
}

void drawLine(int text, int x0, int y0, int x1, int y1) //ребро ориентированный взвешенный граф
{
	glColor3i(0, 0, 0);
	glBegin(GL_LINES);
	glVertex2i(x0, y0);
	glVertex2i(x1, y1);
	glEnd();
	drawText(text, (x0 + x1) / 2 + 10, (y0 + y1) / 2 + 10, false,false,1.0,1.0,1.0);

	float vx = x0 - x1;
	float vy = y0 - y1;
	float s = 1.0f / sqrt(vx * vx + vy * vy);
	vx *= s;
	vy *= s;
	x1 = x1 + R * vx;
	y1 = y1 + R * vy;

	glColor3i(0, 0, 0);
	glBegin(GL_TRIANGLES);
	glVertex2f(x1, y1);
	glVertex2f(x1 + 10 * (vx + vy), y1 + 10 * (vy - vx));
	glVertex2f(x1 + 10 * (vx - vy), y1 + 10 * (vy + vx));
	glEnd();
}


// РИСУЕТ ТРЕУГОЛЬНИК ПО НАПРАВЛЕНИЮ ВЕТВИ
void drawTR(double tr_x, double tr_y, double x1, double y1, int red, int green, int blue) {
	glColor3ub(red, green, blue);
	glBegin(GL_TRIANGLES);
	double g = 7;
	double x = abs(y1 - tr_y) / abs(x1 - tr_x);
	double gamma = atan(x);
	double a = cos(gamma) * g;
	double b = sin(gamma) * g;
	
	if (x1 > tr_x && y1 > tr_y) {
		glVertex2f(x1, y1);
		glVertex2f(tr_x + b, tr_y - a);
		glVertex2f(tr_x - b, tr_y + a);
	}
	else if (x1<tr_x && y1 > tr_y){
		glVertex2f(x1, y1);
		glVertex2f(tr_x + b, tr_y + a);
		glVertex2f(tr_x - b, tr_y - a);
	}
	else if (x1 > tr_x && y1 < tr_y) {
		x = abs(x1 - tr_x) / abs(y1 - tr_y);
		gamma = atan(x);
		a = sin(gamma) * g;
		b = cos(gamma) * g;
		glVertex2f(x1, y1);
		glVertex2f(tr_x + b, tr_y + a);
		glVertex2f(tr_x - b, tr_y - a);
	}
	else if (x1 < tr_x && y1 < tr_y) {
		x = abs(x1 - tr_x) / abs(y1 - tr_y);
		gamma = atan(x);
		a = sin(gamma) * g;
		b = cos(gamma) * g;
		glVertex2f(x1, y1);
		glVertex2f(tr_x + b, tr_y - a);
		glVertex2f(tr_x - b, tr_y + a);
	}
	glEnd();
}


// РИСУЕТ ПОЛОВИНУ ОВАЛА ПО ДВУМ КООРДИНАТАМ
void drawHalfEllipse(
	int text, int x0, int y0, int x1, int y1, int red, int green, int blue, bool flag
) 
{
	double gipot = sqrt(pow(abs(x1 - x0), 2) + pow(abs(y1 - y0), 2));
	double delta = acos(abs(x1 - x0)/gipot), alpha  = 0;
	if (y0 > y1 && x0 < x1) alpha = 2.0f * 3.1415926f - delta;
	else if (y0 > y1 && x0 > x1) alpha = 3.1415926f + delta;
	else if (y0 < y1 && x0 < x1) alpha = delta;
	else if (y0 < y1 && x0 > x1) alpha = 3.1415926f - delta;
	else if (x0 == x1) {
		if (y0 < y1) alpha = delta;
		else if (y0 > y1) alpha = 2.0f * 3.1415926f - delta;
	}
	else if (y0 == y1) {
		if (x0 < x1) alpha = delta;
		else if (x0 > x1) alpha = 3.1415926f;
	}
	else alpha = delta;
	double r = gipot / 8;
	double a = gipot / 2;
	double b = a / 4;
	double dy = y0 <= y1 ? y0 + abs(y0 - y1) / 2 : y1 + abs(y0 - y1) / 2;
	double dx = x0 <= x1 ? x0 + abs(x0 - x1) / 2 : x1 + abs(x0 - x1) / 2;
	double text_x, text_y, tr_x, tr_y, tr_x1,tr_y1;
	glColor3ub(red, green, blue);
	float x2, y2;
	glBegin(GL_POINTS);
	for (int i = 0; i < 1800; i++)
	{
		float theta = 2.0f * 3.1415926f * float(i) / float(3600);
		y2 = a * cos(theta) * sin(alpha) + b * sin(theta) * cos(alpha) + dy;
		x2 = a * cos(theta) * cos(alpha) - b * sin(theta) * sin(alpha) + dx;
		glVertex2f(x2, y2);
		if (i == 900) {
			text_x = x2;
			text_y = y2;
		}

		if (i == 450) {
			tr_x = x2;
			tr_y = y2;
		}
		if (i == 350) {
			tr_x1 = x2;
			tr_y1 = y2;
		}

	}
	glEnd();

	drawTR(tr_x,tr_y,tr_x1,tr_y1,red,green,blue);

	drawText(text, text_x, text_y,true, flag,red,green,blue);
}

template<class T>
void Graph<T>::DrawGraph()
{	

	int n = vertList.size();
	
	if (IS_INIT) {
		for (int i = 0; i < n; i++)
		{
			setCoord(i, n);
		}
		IS_INIT = false;
	}
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			
			int a = adjMatrix[i][j];

			

			if (a != 0)
			{

				if (IS_COM_SOLVED) {
					if (array[i + 1] == j + 1) drawHalfEllipse(a, vertC[i].x, vertC[i].y, vertC[j].x, vertC[j].y, 0,190,0,true);
					else drawHalfEllipse(a, vertC[i].x, vertC[i].y, vertC[j].x, vertC[j].y, 120,120,120,true);
				}
				else drawHalfEllipse(a, vertC[i].x, vertC[i].y, vertC[j].x, vertC[j].y, 0, 0, 0,false);

			}
		}
	}
	drawVertex(n);
	if (IS_LABELS) {
		for (int i = 0; i < n; i++) drawText(infotext[i], vertC[i].x, vertC[i].y + 40, false,false,1.0,1.0,1.0);
	}
}

template <class T>
void Graph<T>::find(int _x, int _y) {
	for (int i = 0; i < vertList.size(); i++) {
		if (_x <= vertC[i].x + R && _x >= vertC[i].x - R && _y <= vertC[i].y + R && _y >= vertC[i].y - R) {
			sel.x = vertC[i].x;
			sel.y = vertC[i].y;
			//cout << "\nВыбран узел номер " << i+1 << endl;
			int x = i + 1;
			FillLabels(x);
			D_method(x);
		}
	}
}

template <class T>
void Graph<T>::move(int _x, int _y) {
	int x1 = _x + R, x2 = _x - R, y1 = _y + R, y2 = _y - R;
	bool flag = true;
	for (int i = 0; i < vertList.size(); i++) {
		if (_x <= vertC[i].x + R && _x >= vertC[i].x - R && _y <= vertC[i].y + R && _y >= vertC[i].y - R) {
			
			//cout << "\nВыбран узел номер " << i + 1 << endl;
			for (int j = 0; j < vertList.size(); j++) {
				if (j != i) {
					if (x1 <= vertC[j].x + R && x1 >= vertC[j].x - R && y1 <= vertC[j].y + R && y1 >= vertC[j].y - R) flag = false;
					if (x1 <= vertC[j].x + R && x1 >= vertC[j].x - R && y2 <= vertC[j].y + R && y2 >= vertC[j].y - R) flag = false;
					if (x2 <= vertC[j].x + R && x2 >= vertC[j].x - R && y1 <= vertC[j].y + R && y1 >= vertC[j].y - R) flag = false;
					if (x2 <= vertC[j].x + R && x2 >= vertC[j].x - R && y2 <= vertC[j].y + R && y2 >= vertC[j].y - R) flag = false;
				}
			}
			if (flag) {
				vertC[i].x = _x;
				vertC[i].y = _y;
				glutPostRedisplay();
			}
			
		}
	}
}

template <class T> 
void Graph<T>::InitLabels() {
	labelList.clear();
	IS_LABELS = true;
	for (int i = 0; i < vertList.size(); ++i)
		labelList.push_back(1000000);
}

template <class T>
void Graph<T>::FillLabels(T& startVertex) {
	labelList.clear();
	for (int i = 0; i < vertList.size(); ++i)
		labelList.push_back(1000000);
	int pos = GetVertPos(startVertex);
	labelList[pos] = 0;
}

template <class T>
bool Graph<T>::AllVisited(int* vV)
{

	bool flag = true; //Изначально считается, что все вершины обработаны 

	for (int i = 0; i < vertList.size(); i++) {
		if (vV[i] != 1) flag = false;
	} //Если есть хотя бы одна необработанная вершина - флаг принимает значение 	 //Если есть хотя бы одна необработанная вершина - флаг принимает значение 
	
	return flag; //Возвращается значение флага: true если все обработаны, false в ином случае
}

template <class T>
int Graph<T>::D_method(T& startVertex) {

	for (int i = 0; i < SIZE; i++) visitedVerts[i] = 0;
	infotext.clear();
	for (int i = 0; i < SIZE; i++) infotext.push_back(0);

	for (int i = 0; i < vertList.size(); i++) {
		for (int j = 0; j < vertList.size(); j++) {
			if (adjMatrix[i][j] < 0) return -1;
			if (GetVertPos(startVertex) == -1) return -2;
		}
	}

	T curSrc; //Объявление опорной вершины абстрактного типа Т 
	int counter = 0; //Счетчик обработанных меток
	int minLabel = 1000000; //Переменная для хранения минимальной метки
	vector<T> neighbors = GetNbrs(startVertex); //Вектор из соседей текущей обрабатываемой вершины 
	for (int i = 0; i < neighbors.size(); ++i)
	{
		int startLabel = labelList[GetVertPos(startVertex)]; //метка текущей вершины 
		int weight = GetWeight(startVertex, neighbors[i]); //вес ребра до соседней вершины 
		int nIndex = GetVertPos(neighbors[i]); //индекс соседней вершины 
		int nextLabel = labelList[nIndex]; //метка соседней вершины
		if (startLabel + weight < nextLabel) //Если значение суммы текущей метки и веса ребра меньше значения соседней метки 
			labelList[nIndex] = startLabel + weight; //Обновление соседней метки 
		if (labelList[nIndex] < minLabel)
			minLabel = labelList[nIndex]; //Определение наименьшей метки у соседних вершин
	}
	for (int i = 0; i < neighbors.size(); ++i) //Все ли соседние вершины проверены 
		if (labelList[GetVertPos(neighbors[i])] != 1000000)
			counter += 1;

	if (counter == neighbors.size()) //Текущая вершина помечается обработанной 
	{
		visitedVerts[GetVertPos(startVertex)] = 1;
	}
	for (int i = 0; i < neighbors.size(); ++i) //Поиск новой опорной вершины с наименьшей меткой 
		if (labelList[GetVertPos(neighbors[i])] == minLabel) 
			curSrc = neighbors[i];

	while (!AllVisited(visitedVerts)) //Пока все вершины не обработаны
	{
		
		neighbors = GetNbrs(curSrc); //Вектор соседей новой опорной вершины 
		int count = 0;
		minLabel = 1000000;
		for (int i = 0; i < neighbors.size(); i++) //Обход соседних вершин
		{
			int curLabel = labelList[GetVertPos(curSrc)]; //Метка текущей опорной вершины 
			int weight = GetWeight(curSrc, neighbors[i]); //Вес ребра до соседней вершины 
			int nIndex = GetVertPos(neighbors[i]); //Индекс соседней вершины 
			int nextLabel = labelList[nIndex]; //Метка соседней

			if ((curLabel + weight) < nextLabel) //Если значение суммы текущей метки и веса ребра меньше значения соседней метки 
				labelList[nIndex] = curLabel + weight; //Метка соседней вершины обновляется

			if (labelList[nIndex] < minLabel && visitedVerts[nIndex] != 1) //Поиск минимальной метки среди не обработанных 
				minLabel = labelList[nIndex];

			count += 1; //Подсчёт посещённых соседей
		}
		if (count == neighbors.size()) //Если все соседи посещены 
		{
			visitedVerts[GetVertPos(curSrc)] = 1;
		} //Опорная вершина помечается обработанной

		bool flag = false;
		for (int i = 0; i < neighbors.size(); ++i) { //Поиск новой опорной вершины 
			if (labelList[GetVertPos(neighbors[i])] == minLabel || visitedVerts[GetVertPos(neighbors[i])] != 1) {
				flag = true;
				curSrc = neighbors[i];
			}
		}
		if (!flag) {
			int min = 100000;
			for (int i = 0; i < labelList.size(); i++) {
				if (labelList[i] <= min && labelList[i] != 0 && visitedVerts[i] != 1) {
					min = labelList[i];
					curSrc = i+1;
				}
			}
		}
	}


	for (int i = 0; i < GetVertPos(startVertex); ++i)
	{
		infotext[i] = labelList[GetVertPos(vertList[i])];
		cout << "Кратчайшее расстояние от вершины " << startVertex << " до вершины " << vertList[i] << " равно "
			<< labelList[GetVertPos(vertList[i])] << endl;

	}
	for (int i = GetVertPos(startVertex) + 1; i < vertList.size(); ++i)
	{
		infotext[i] = labelList[GetVertPos(vertList[i])];
		cout << "Кратчайшее расстояние от вершины " << startVertex << " до вершины " << vertList[i] << " равно "
			<< labelList[GetVertPos(vertList[i])] << endl;
	}

}


// ЗАДАЧА КОММИВОЯЖЕРА

// ПРОВЕРКА НА ЦИКЛЫ ГАМИЛЬТОНА
template <class T>
bool Graph<T>::hamilton(int curr)
{	
	Path.insert(Path.begin(),curr);
	if (Path.size() == SIZE)
		if (adjMatrix[Path[0]][Path.back()] >= 1)
			return true;
		else
		{
			Path.pop_back();
			return false;
		}

	Visited[curr] = true;
	for (int nxt = 0; nxt < SIZE; ++nxt)
		if (adjMatrix[curr][nxt] >= 1 && !Visited[nxt])
			if (hamilton(nxt))
				return true;
	Visited[curr] = false;
	Path.pop_back();
	return false;
}

// ПЕЧАТЬ ТЕКУЩЕЙ МАТРИЦЫ В КОНСОЛЬ
template<class T>
void Graph<T>::temp_COM_Print() {
	cout << endl;
	if (!this->IsEmpty()) {
		cout << "Матрица смежности графа: " << endl;
		for (int i = 0, vertListSize = this->vertList.size(); i < vertListSize; ++i) {

			cout << (this->vertList[i]) << " ";
			for (int j = 0; j < vertListSize; ++j) {
				cout << " " << this->temp_COM_adjMatrix[i][j] << " ";
			}
			cout << endl;
		}
	}
	else {
		cout << "Граф пуст " << endl;
	}
}

// ПРОВЕРКА МАТРИЦЫ НА НАЛИЧИЕ В НЕЙ ЭЛЕМЕНТОВ, ОТЛИЧНЫХ ОТ -1
bool IS_INF(int** matrix, int SIZE) {
	bool f  = true;
	for (int i = 0; i < SIZE; ++i) {
		for (int j = 0; j < SIZE; ++j) {
			if (matrix[i][j] != -1) f = false;
		}
	}
	return f;
}

// РЕДУКЦИЯ СТРОК И СТОЛБЦОВ (ВЫЧИТАНИЕ МИНИМАЛНЫХ ЭЛЕМЕНТОВ)
template <class T>
int Graph<T>::COM_rows_columns(T** matrix) {

	int MINROAD = 0;
	int* min_rows = new int[SIZE];
	int* min_columns = new int[SIZE];

	for (int i = 0; i < SIZE; i++) {
		min_rows[i] = 10000;
		min_columns[i] = 10000;
	}

	for (int i = 0; i < SIZE; ++i) {
		for (int j = 0; j < SIZE; ++j) {
			if (matrix[i][j] > -1) {
				if (matrix[i][j] < min_rows[i]) min_rows[i] = matrix[i][j];
			}
		}
	}

	for (int i = 0; i < SIZE; i++) {
		if (min_rows[i] < 9000) MINROAD += min_rows[i];
	}

	for (int i = 0; i < SIZE; ++i) {
		for (int j = 0; j < SIZE; ++j) {
			if (matrix[i][j] > -1) {
				matrix[i][j] -= min_rows[i];
			}
		}
	}

	for (int i = 0; i < SIZE; ++i) {
		for (int j = 0; j < SIZE; ++j) {
			if (matrix[i][j] > -1) {
				if (matrix[i][j] < min_columns[j]) min_columns[j] = matrix[i][j];
			}
		}
	}

	for (int i = 0; i < SIZE; i++) {
		if (min_columns[i] < 9000) MINROAD += min_columns[i];
	}

	for (int i = 0; i < SIZE; ++i) {
		for (int j = 0; j < SIZE; ++j) {
			if (matrix[i][j] > -1) {
				matrix[i][j] -= min_columns[j];
			}
		}
	}

	return MINROAD;
}

// ПОДСЧЕТ ШТРАФОВ НУЛЯ
template <class T>
int Graph<T>::zero_mark(int i, int j) {
	int min_i = 0, min_j = 0, zero_mark;
	bool f = true;
	for (int k = 0; k < SIZE && f; ++k) {
		if (temp_COM_adjMatrix[i][k] > -1 && k != j) {
			min_i = temp_COM_adjMatrix[i][k];
			f = false;
		}
	}


	for (int n = 0; n < SIZE; ++n) {
		if (n != j) {
			if (temp_COM_adjMatrix[i][n] > -1) {
				if (temp_COM_adjMatrix[i][n] <= min_i) {
					min_i = temp_COM_adjMatrix[i][n];
				}
			}
		}
	}


	min_j = 0;
	f = true;
	for (int k = 0; k < SIZE && f; ++k) {
		if (temp_COM_adjMatrix[k][j] > -1 && k != i) {
			min_j = temp_COM_adjMatrix[k][j];
			f = false;
		}
	}


	for (int n = 0; n < SIZE; ++n) {
		if (n != i) {
			if (temp_COM_adjMatrix[n][j] > -1) {
				if (temp_COM_adjMatrix[n][j] <= min_j) {
					min_j = temp_COM_adjMatrix[n][j];
				}
			}
		}
	}
	return min_i + min_j;
}

// РЕШЕНИЕ ЗАДАЧИ КОММИВОЯЖЕРА
template <class T>
int Graph<T>::Commute_problem() {

	temp_COM_adjMatrix = new T * [SIZE];
	temp1_COM_adjMatrix = new T * [SIZE];
	temp2_COM_adjMatrix = new T * [SIZE];
	for (int i = 0; i < vertList.size(); ++i) {
		temp_COM_adjMatrix[i] = new int[vertList.size()];
		temp1_COM_adjMatrix[i] = new int[vertList.size()];
		temp2_COM_adjMatrix[i] = new int[vertList.size()];
	}
	for (int i = 0; i < vertList.size(); ++i) {
		for (int j = 0; j < vertList.size(); ++j) {
			this->temp_COM_adjMatrix[i][j] = -1;
		}
	}

	for (int i = 0; i < vertList.size(); ++i) {
		for (int j = 0; j < vertList.size(); ++j){
			if (adjMatrix[i][j] != 0) temp_COM_adjMatrix[i][j] = adjMatrix[i][j];
		}
	}

	temp_COM_Print();
	int L_b = 100;
	int c = 0;
	int cur_road;	
	cur_road = COM_rows_columns(temp_COM_adjMatrix);
	int m = 0;

	if (SIZE == 2) {
		array[1] = 2;
		array[2] = 1;
	}
	else {

		while (m < SIZE)
		{
			//cout << "yes";
	// ПОДСЧЕТ ШТРАФОВ НУЛЕЙ

			int mark = -1, temp_mark;
			int zero_i = 0, zero_j = 0;

			for (int i = 0; i < SIZE; ++i) {
				for (int j = 0; j < SIZE; ++j) {
					if (temp_COM_adjMatrix[i][j] > -1) {
						if (temp_COM_adjMatrix[i][j] == 0) {
							temp_mark = zero_mark(i, j);
							if (temp_mark > mark) {
								mark = temp_mark;
								zero_i = i;
								zero_j = j;
							}
						}
					}
				}
			}

			temp_COM_adjMatrix[zero_i][zero_j] = -1;

			// СОЗДАНИЕ ДВУХ МАТРИЦ И ПОДСЧЕТ ИХ ОПТИМИСТИЧЕСКОЙ ДЛИНЫ

			// МАТРИЦА, ВКЛЮЧАЮЩАЯ X
			for (int i = 0; i < SIZE; ++i) {
				for (int j = 0; j < SIZE; ++j) {
					if (i == zero_i || j == zero_j) temp1_COM_adjMatrix[i][j] = -1;
					else temp1_COM_adjMatrix[i][j] = temp_COM_adjMatrix[i][j];
				}
			}
			temp1_COM_adjMatrix[zero_i][zero_j] = -1;
			temp1_COM_adjMatrix[zero_j][zero_i] = -1;

			int MINROAD_1 = cur_road + COM_rows_columns(temp1_COM_adjMatrix);

			// МАТРИЦА, НЕ ВКЛЮЧАЮЩАЯ X
			for (int i = 0; i < SIZE; ++i) {
				for (int j = 0; j < SIZE; ++j) {
					temp2_COM_adjMatrix[i][j] = temp_COM_adjMatrix[i][j];
				}
			}
			temp2_COM_adjMatrix[zero_i][zero_j] = -1;

			int MINROAD_2 = cur_road + COM_rows_columns(temp2_COM_adjMatrix);

			// СРАВНЕНИЕ ПОЛУЧЕННЫХ ЗНАЧЕНИЙ ДЛИН

			if (MINROAD_1 <= MINROAD_2) {
				if (m + 1 == SIZE) temp1_COM_adjMatrix[zero_i][zero_j] = 0;
				if (IS_INF(temp1_COM_adjMatrix, SIZE)) {
					cur_road = MINROAD_2;
					for (int i = 0; i < SIZE; ++i) {
						for (int j = 0; j < SIZE; ++j) {
							temp_COM_adjMatrix[i][j] = temp2_COM_adjMatrix[i][j];
						}
					}
					m--;
				}
				else {
					cur_road = MINROAD_1;
					for (int i = 0; i < SIZE; ++i) {
						for (int j = 0; j < SIZE; ++j) {
							temp_COM_adjMatrix[i][j] = temp1_COM_adjMatrix[i][j];
						}
					}
					array[zero_i + 1] = zero_j + 1;
				}

			}
			else {
				cur_road = MINROAD_2;
				for (int i = 0; i < SIZE; ++i) {
					for (int j = 0; j < SIZE; ++j) {
						temp_COM_adjMatrix[i][j] = temp2_COM_adjMatrix[i][j];
					}
				}

				array[zero_i + 1] = zero_j + 1;
			}

			m++;
			c++;
			if (c > 20) break;
		}

	}
	

	cout << "\nОтвет: \n";

	cout << "Длина пути: " << cur_road << endl;
	int x = 1;
	cout << x;
	for (int i = 1; i <= SIZE; ++i) {
		cout<<" -> " << array[x];
		x = array[x];
	}

	IS_COM_SOLVED = true;
	return cur_road;
}

