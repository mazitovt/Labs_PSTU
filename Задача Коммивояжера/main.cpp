// ГРУППА: РИС-19-1б
// ФИО: МАЗИТОВ ТИМУР ЭМИЛЕВИЧ
// ВАРИАНТ 17.
// ТВОРЧЕСКОЕ ЗАДАНИЕ ЧАСТЬ 1:ЗАДАЧА КОММИВОЯЖЕРА

#include <glut.h>
#include "iostream"
#include <ctime>
#include "Graph.h"
#include <conio.h>
#include <locale>
#include <ctime>
using namespace std;

Graph<int> graph;

// СТРУКТУРА КНОПКА
struct BUTTON {
    string text;
    int red;
    int green;
    int blue;
    int x1;
    int y1;
    int x2;
    int y2;
    int x_mid;
    int y_mid;
    BUTTON(int _x1, int _y1, int _x2, int _y2, int _r, int _g, int _b, string t) : x1(_x1), y1(_y1), x2(_x2), y2(_y2), red(_r), green(_g), blue(_b), text(t) {
        x_mid = x1 + (x2 - x1) / 2;
        y_mid = y1 + (y2 - y1) / 2;
    }
    bool is_clicked(int x, int y) {
        if (x >= x1 && x <= x2 && y >= y1 && y <= y2) return true;
        else return false;
    }
}   LEN_BTN(20, 20, 350, 60, 100, 100, 100, "Solve TSP");

// ОТРИСОВКА ТЕКСТА КНОПКИ 
void ButtonText(float x, float y, string s, void* font) {
    glColor3ub(255, 255, 255);
    glPushMatrix();
    char* s1 = new char[s.size() + 1];
    for (int i = 0; i < s.size(); i++) {
        s1[i] = s.at(i);
    }
    s1[s.size()] = 0;
    char* c;
    glTranslatef(x - 120, y - 10, 0);
    glScalef(0.2, 0.2, 1.0);
    for (c = s1; *c != '\0'; c++)
        glutStrokeCharacter(font, *c);
    glPopMatrix();
}

// ОТРИСОВКА КНОПКИ
void drawButtons() {
    glColor3ub(LEN_BTN.red, LEN_BTN.green, LEN_BTN.blue);
    glRecti(LEN_BTN.x1, LEN_BTN.y1, LEN_BTN.x2, LEN_BTN.y2);
    ButtonText(LEN_BTN.x_mid, LEN_BTN.y_mid, LEN_BTN.text, GLUT_STROKE_ROMAN);
}

// ОТРИСОВКА ОКНА
void display() {
    glClearColor(1.0, 1.0, 1.0, 1.0);
    glClear(GL_COLOR_BUFFER_BIT);
    drawButtons();
    graph.DrawGraph();
    glutSwapBuffers();
}

// ВЫЗОВ ФУНКЦИИ РЕШЕНИЯ ЗАДАЧИ КОММИВОЯЖЕРА
void mouse(int button, int state, int _x, int _y) {
    if (state == GLUT_DOWN && LEN_BTN.is_clicked(_x, 700-_y)) {
        if (graph.hamilton(0)) {
            int x = graph.Commute_problem();
            LEN_BTN.red = 0;
            LEN_BTN.green = 150;
            LEN_BTN.blue = 0;
            LEN_BTN.text = "Solve TSP: " + to_string(x);
        }
        else { 
            LEN_BTN.red = 150;
            LEN_BTN.green = 0;
            LEN_BTN.blue = 0;
            LEN_BTN.text = "TSP can't be solved";
            cout << "\nНельзя решить\n"; 
        }
        glutPostRedisplay();
    }
}

// ПЕРЕМЕЩЕНИЕ УЗЛА ГРАФА
void move(int _x, int _y) {
    graph.move(_x, 700 - (_y));
}

// СОЗДАНИЕ ГРАФА ИЗ 17 ВАРИАНТА С 6 УЗЛАМИ И 9 ВЕТКАМИ
void make_graph_v17() {
    int amountVerts, amountEdges, vertex, sourceVertex, targetVertex, edgeWeight; // создание необходимых для ввода графа переменных

    amountVerts = 6;
    amountEdges = 9;

    graph.set_size(amountVerts);
    graph.InitVariables();
    cout << "Количество вершин графа: " << amountVerts; cout << endl;
    cout << "Количество ребер графа: " << amountEdges; cout << endl;

    for (int i = 1; i <= amountVerts; ++i) {
        vertex = i;
        cout << "Вершина: " << vertex; // ввод вершины
        int* vertPtr = &vertex; // запоминаем адрес вершины            
        graph.InsertVertex(*vertPtr); //передаём ссылку на вершину 
        cout << endl;
    }

    graph.InsertEdge(1, 2, 14);
    graph.InsertEdge(2, 5, 42);
    graph.InsertEdge(2, 6, 23);
    graph.InsertEdge(5, 3, 18);
    graph.InsertEdge(3, 4, 9);
    graph.InsertEdge(3, 1, 19);
    graph.InsertEdge(4, 6, 31);
    graph.InsertEdge(6, 1, 28);
    graph.InsertEdge(6, 2, 23);

}

// СОЗДАНИЕ ГРАФА С 4 УЗЛАМИ И 12 ВЕТКАМИ
void make_graph_4_12() {
    int amountVerts, amountEdges, vertex, sourceVertex, targetVertex, edgeWeight; // создание необходимых для ввода графа переменных

    amountVerts = 4;
    amountEdges = 12;

    graph.set_size(amountVerts);
    graph.InitVariables();
    cout << "Количество вершин графа: " << amountVerts; cout << endl;
    cout << "Количество ребер графа: " << amountEdges; cout << endl;

    for (int i = 1; i <= amountVerts; ++i) {
        vertex = i;
        cout << "Вершина: " << vertex; // ввод вершины
        int* vertPtr = &vertex; // запоминаем адрес вершины            
        graph.InsertVertex(*vertPtr); //передаём ссылку на вершину 
        cout << endl;
    }
   

    graph.InsertEdge(1, 2, rand() % 100);
    graph.InsertEdge(1, 3, rand() % 100);
    graph.InsertEdge(1, 4, rand() % 100);
    graph.InsertEdge(2, 1, rand() % 100);
    graph.InsertEdge(2, 3, rand() % 100);
    graph.InsertEdge(2, 4, rand() % 100);
    graph.InsertEdge(3, 1, rand() % 100);
    graph.InsertEdge(3, 2, rand() % 100);
    graph.InsertEdge(3, 4, rand() % 100);
    graph.InsertEdge(4, 1, rand() % 100);
    graph.InsertEdge(4, 2, rand() % 100);
    graph.InsertEdge(4, 3, rand() % 100);

}

// СОЗДАНИЕ ГРАФА И ЗАПОЛНЕНИЕ ДАННЫХ
void make_graph()
{

    int amountVerts, amountEdges, vertex, sourceVertex, targetVertex, edgeWeight; // создание необходимых для ввода графа переменных

    do {
        cout << "Введите количество вершин графа (больше 1): "; cin >> amountVerts; cout << endl; // ввод количества рёбер графа в переменную amountVerts
    } while (amountVerts <= 1);

    do {
        cout << "Введите количество ребер графа (больше 1): "; cin >> amountEdges; cout << endl; // ввод количества рёбер графа в переменную amountEdges
    } while (amountEdges <= 1);

    graph.set_size(amountVerts);
    graph.InitVariables();
    cout << "Количество вершин графа: " << amountVerts; cout << endl;
    cout << "Количество ребер графа: " << amountEdges; cout << endl;

    for (int i = 1; i <= amountVerts; ++i) {
        vertex = i;
        cout << "Вершина: " << vertex; // ввод вершины
        int* vertPtr = &vertex; // запоминаем адрес вершины            
        graph.InsertVertex(*vertPtr); //передаём ссылку на вершину 
        cout << endl;
    }

    for (int i = 0; i < amountEdges; ++i) {
        cout << "Исходная вершина: "; cin >> sourceVertex;  // ввод исходной вершины
        int* sourceVertPtr = &sourceVertex; // запоминаем адрес исходной вершины
        cout << "Конечная вершина: "; cin >> targetVertex;  // ввод вершины, до которой будет идти ребро от исходной вершины
        int* targetVertPtr = &targetVertex; // запоминаем адрес конечной вершины (до которой будет идти ребро от исходной вершины)
        do {
            cout << "Вес ребра (от 1 до 99): "; cin >> edgeWeight; cout << endl; // ввод числового значения веса ребра в переменную edgeWeight
        } while (edgeWeight < 1 || edgeWeight > 99);
        
        graph.InsertEdge(*sourceVertPtr, *targetVertPtr, edgeWeight); // вставка ребра весом edgeWeight между исходной и конечной вершинами
    }

}

// ВЫБОР ПОЛЬЗОВАТЕЛЯ
void menu() {

    setlocale(LC_ALL, "Russian");
    bool flag = true;
    int choice;

    cout << "\nМеню:\n";
    cout << "1. Решить задачу варианта 17 с 6 узлами и 9 ветками;\n";
    cout << "2. Решить задачу с 4 узлами и 12 ветками со случайным весом;\n";
    cout << "3. Ввести свои значения.\n";
    do {
        cout << "Введите число от 1 до 3: ";
        cin >> choice;
    } while (choice != 1 && choice != 2 && choice != 3);

    switch (choice) {
    case 1: make_graph_v17(); break;
    case 2: make_graph_4_12(); break;
    case 3: make_graph(); break;
    }

}

// ВХОДНАЯ ФУНКЦИЯ
int main(int argc, char** argv)
{
    //// инициализация
    srand(time(NULL));
    menu();
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DEPTH | GLUT_RGBA);
    glutInitWindowSize(700, 700);
    glutInitWindowPosition(50, 50);
    glutCreateWindow("Задача Коммивояжера");
    glClearColor(0.25, 0.95, 0.46, 1.0);
    glOrtho(0, 700,0 , 700, -5.0, 5.0);
    glutMouseFunc(mouse);
    glutMotionFunc(move);
    // регистрация обратных вызовов
    glutDisplayFunc(display);
    // Основной цикл GLUT
    glutMainLoop();

    return 0;
}