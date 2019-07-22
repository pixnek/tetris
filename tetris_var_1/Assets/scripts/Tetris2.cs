using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tetris2 : MonoBehaviour {

	int [,]table;//сетка игры, где 2 - зафиксированный блок, 3 и 1 - падающая фигура

	GameObject pfbBlock;//префаб блока, где 1 - темный блок, 2 - свеьлый блок

	Sprite spriteDark;//спрайт темного блока
	Sprite spriteLight;//спрайт светлого блока

	Figure figure;//объект класса падающей фигуры.

	int widthTable;//ширина игрового поля
	int heightTable;//высота игрового поля

	GameObject [,] allBlock;//массив блоков

	float []randomValue;//массив значений вероятностей

	class Figure {//класс падающей фигуры

		int yCoord;// x-координата правого верхнего угла описанного квадрата около фигуры
		int xCoord;// y-координата правого верхнего угла описанного квадрата около фигуры
		int[,] figure;// маска фигуры (положение фигуры на игровом поле).
		int size;// размеры описанного квадрата

		public Figure(int n){
			yCoord=0;
			xCoord=5;
			switch(n){
			case 1://фигура квадрат **
				//					**
				size = 2;
				figure = new int[2,2]{
					{1,3},
					{3,1},
				};
				break;
			case 2://фигура **
				//			 **
				yCoord=-1;
				size = 3;
				figure = new int[3,3]{
					{0,0,0},
					{1,3,0},
					{0,1,3},
				};
				break;
			case 3:// фигура  **
				//			 **
				yCoord=-1;
				size = 3;
				figure = new int[3,3]{
					{0,0,0},
					{0,3,1},
					{3,1,0},
				};
				break;
			case 4://фигура отображенная буква "Г" на спине    *
				//											 ***
				size = 3;
				figure = new int[3,3]{
					{0,0,1},
					{3,1,3},
					{0,0,0},
				};
				break;
			case 5://фигура буква "Г" на спине  *
				//								***
				size = 3;
				figure = new int[3,3]{
					{1,0,0},
					{3,1,3},
					{0,0,0},
				};
				break;
			case 7:// Т-образная фигура   *
				//						 ***
				size=3;
				figure = new int[3,3]{
					{0,1,0},
					{1,3,1},
					{0,0,0},
				};
				break;
			case 6:// фигура вида палочки ****
				yCoord=-1;
				size = 4;
				figure = new int[4,4]{
					{0,0,0,0},
					{3,1,3,1},
					{0,0,0,0},
					{0,0,0,0},
				};
				break;
			case 8:
				size=3;
				figure = new int[3,3]{
					{0,1,0},
					{1,3,1},
					{0,1,0},
				};
				break;
			case 9:
				yCoord=-1;
				size=3;
				figure = new int[3,3]{
					{0,0,0},
					{1,3,1},
					{3,0,3},
				};
				break;
			case 10:
				size=3;
				figure = new int[3,3]{
					{3,0,0},
					{1,3,0},
					{0,1,3},
				};
				break;
			default:
				break;
			}
		}
		public void SetFigure(int [,]tmpFigure){//вызывается при выполнения условий поворота.
			figure = tmpFigure;
		}
		public int [,] Rotate(){// возвращает повернутую фигуру в описанном квадрате
			int[,] tmp=new int[size,size];
			if (size != 4) {//если не палочка
				if (size != 2) {//если не квадрат
					for (int y = 0; y < size; y++) {
						for (int x = 0; x < size; x++) {
							tmp [2 - x, y] = figure [y, x];//поварачиваем фигуру против часовой стрелки на 90 градусов
						}
					}
				} else {//у квадрата меняем спрайты
					tmp [0, 0] = figure [0, 1];
					tmp [0, 1] = figure [0, 0];
					tmp [1, 0] = figure [1, 1];
					tmp [1, 1] = figure [1, 0];
				}
			} else {//для палочки отдельное вращение
				if (figure [1, 0] > 0) {
					tmp = new int[4, 4] {
						{ 0, 3, 0, 0 },
						{ 0, 1, 0, 0 },
						{ 0, 3, 0, 0 },
						{ 0, 1, 0, 0 },
					};
				} else {
					tmp = new int[4, 4] {
						{ 0, 0, 0, 0 },
						{ 3, 1, 3, 1 },
						{ 0, 0, 0, 0 },
						{ 0, 0, 0, 0 },
					};
				}
			}
			return tmp;
		}
		public int GetSize(){//Возвращает размер описанного квадрата
			return size;
		}
		public int [] GetCoord(){//Возвращает координаты начала описанного квадрата
			int []tmp= new int[2];
			tmp [0] = yCoord;
			tmp [1] = xCoord;
			return tmp;
		}
		public int[,] GetFigure(){//Возвращаем описанный квадрат с фигурой
			return figure;
		}
		public void AddXCoord(int widthTable){//увеличивает x-координату начала описанного квадрата. Вызывается при успешном выполнении функции MoveRight
			xCoord++;
			if (xCoord > (widthTable-1)) {
				xCoord -= widthTable;
			}
		}
		public void AddYCoord(){// увеличивает y-координату начала описанного квадрата. Вызывается при успешном выполнении функции MoveDown
			yCoord++;
		}
		public void DeductXCoord(int widthTable){// уменьшает x-координату начала описанного квадрата. Вызывается при успешном выполнении функции MoveLeft
			xCoord--;
			if (xCoord < 0) {
				xCoord += widthTable;
			}
		}
	}

	// Use this for initialization
	void Fill (){//Заполнение сцены объектами
		allBlock = new GameObject[heightTable, widthTable];
		for (int y = 0; y < heightTable; y++) {
			for (int x = 0; x < widthTable; x++) {
				allBlock [y, x] = GameObject.Instantiate (pfbBlock);
				allBlock [y, x].transform.position = new Vector3 (x,19 - y, 0);
			}
		}
	}

	void Start () {
		pfbBlock = Resources.Load<GameObject> ("prefabs/Block");//Подгружаем ресурсы
		spriteDark = Resources.Load<Sprite> ("texture/1");
		spriteLight = Resources.Load<Sprite> ("texture/2");

		heightTable = 20;//задаем высоту игрового поля
		widthTable = 12;//задаем ширину игрового поля

		randomValue = new float []{0.1f,0.15f,0.15f,0.15f,0.15f,0.1f,0.05f,0.05f,0.05f,0.05f,};
		table = new int[,] {//инициализация сетки игры
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		};
		Fill ();
		AddFigure ();
		Draw ();
		InvokeRepeating ("MoveDown", 1, 0.5f);
	}

	//Поворот фигуры
	void Rotate(){
		int[,] tmpFigure = figure.Rotate ();
		int size = figure.GetSize ();
		int[] coord = figure.GetCoord ();
		int[,] tmpTable = new int[size, size];

		for (int y = coord [0]; y < coord [0] + size; y++) {
			for (int x = coord [1]; x < coord [1] + size; x++) {
				if ((y >= 0) && (y < heightTable)) {
					tmpTable [y - coord [0], x - coord [1]] = table [y, ((x+widthTable)%widthTable)];
					if (table [y, ((x+widthTable)%widthTable)] == 2) {
						return;
					}
				} else {
					if (tmpFigure [y - coord [0], x - coord [1]] != 0) {
						return;
					}
				}
			}
		}

		for (int y = coord [0]; y < coord [0] + size; y++) {
			for (int x = coord [1]; x < coord [1] + size; x++) {
				if ((y >= 0) && (y < heightTable) ) {
					table [y, ((x+widthTable)%widthTable)] = tmpFigure [y - coord [0], x - coord [1]];
				}
			}
		}
		figure.SetFigure (tmpFigure);
	}

	//Добавлене фигуры
	void AddFigure(){
		int n = RandomFigure ();
		figure = new Figure (n);
		n = figure.GetSize ();
		int[] coord = figure.GetCoord ();
		int[,] tmp = new int[n, n];
		int[,] tmpFigure = figure.GetFigure ();

		for (int y = coord [0]; y < coord [0] + n; y++) {
			for (int x = coord [1]; x < coord [1] + n; x++) {
				if (y >= 0) {
					tmp [y - coord [0], x - coord [1]] = table [y, x];
					if (tmpFigure [y - coord [0], x - coord [1]] > 0 && tmp [y - coord [0], x - coord [1]] == 2) {
						return;
					}
				}
			}
		}

		for (int y = coord [0]; y < coord [0] + n; y++) {
			for (int x = coord [1]; x < coord [1] + n; x++) {
				if (y >= 0) {
					table [y, x] = tmpFigure [y - coord [0], x - coord [1]];
				}
			}
		}

	}

	//Вычисление какая будет добавлена фигура
	int RandomFigure(){
		float total = 0;
		foreach (float elem in randomValue) {
			total += elem;
		}
		float randomPoint = Random.value * total;
		for (int i = 0; i < randomValue.Length; i++) {
			if (randomPoint < randomValue [i]) {
				return (i+1);
			} else {
				randomPoint -= randomValue [i];
			}
		}
		return randomValue.Length;
	}

	//прорисовка блоков
	void Draw(){
		for (int y = 0; y < heightTable; y++) {
			for (int x = 0; x < widthTable; x++) {
				if (table [y,x] > 0) {
					if (table [y, x] == 1) {
						allBlock [y, x].GetComponent<SpriteRenderer> ().sprite = spriteDark;
					}
					if (table [y, x] == 3) {
						allBlock [y, x].GetComponent<SpriteRenderer> ().sprite = spriteLight;
					}
					allBlock [y,x].SetActive (true);//если в сетке игры значение больше нуля, то отобразить блок
				} else {
					allBlock [y,x].SetActive (false);//иначе скрыть
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("right")) {
			MoveRight ();
		}
		if (Input.GetKeyDown ("left")) {
			MoveLeft ();
		}
		if (Input.GetKeyDown ("space")) {
			Rotate ();
		}
		Draw ();
	}

	//Удаляем собранные линии
	void CleanLine(int y){
		for (int x = 0; x < widthTable; x++) {
			table [y, x] = 0;
		}
		DownBlocks (y);
		Text Score = GameObject.Find ("Canvas/Text").GetComponent<Text>();
		int tmpScore = int.Parse (Score.text);
		tmpScore += 100;
		Score.text = tmpScore.ToString ();
	}

	//опускаем фиксированные значения вниз
	void DownBlocks(int yStart){
		for (int y = yStart; y > 0; y--) {
			for (int x = 0; x < widthTable; x++) {
				if ((table [y, x] == 0) && (table [y - 1, x] == 2)) {
					table [y, x] = 2;
					table [y - 1, x] = 0;
					allBlock [y - 1, x].GetComponent<SpriteRenderer> ().sprite = allBlock [y - 1, x].GetComponent<SpriteRenderer> ().sprite;
				}
			}
		}
	}

	//Проверяем есть ли собранные линии
	void CheckLine(){
		int lastYFull=-2;
		for (int y = heightTable-1; y >0; y--) {
			int sum = 0;
			for (int x = 0; x < widthTable; x++) {
				sum = sum + table [y, x];
			}
			if (sum == 2*widthTable) {
				if (Mathf.Abs (y - lastYFull) == 1) {
					CleanLine (lastYFull);
					CleanLine (lastYFull);
					lastYFull = -2;
					y += 2;
				} else {
					lastYFull = y;
				}
			}
		}
	}

	//Движение вправо
	void MoveRight(){
		int [,]tmp=new int[heightTable,widthTable];
		for (int y = 0; y < heightTable; y++) {
			for (int x = 0; x < widthTable; x++) {
				if (table [y, x] == 1 || table [y, x] == 3) {
					if (table [y,(((x+1)+widthTable)%widthTable)] == 2) {
						return;
					}
					tmp [y, (((x+1)+widthTable)%widthTable)] = table [y, x];
				}
				if (table [y, x] == 2) {
					tmp [y, x] = 2;
				}
			}
		}
		table = tmp;
		figure.AddXCoord (widthTable);
	}

	//Движение влево
	void MoveLeft(){
		int [,]tmp=new int[20,12];
		for (int y = 0; y < 20; y++) {
			for (int x = 0; x < 12; x++) {
				if (table [y, x] == 1 || table [y, x] == 3) {
					if (table [y, (((x-1)+12)%12)] == 2) {
						return;
					}
					tmp [y, (((x-1)+12)%12)] = table [y, x];
				}
				if (table [y, x] == 2) {
					tmp [y, x] = 2;
				}
			}
		}
		table = tmp;
		figure.DeductXCoord (widthTable);
	}

	//падение фигуры
	void MoveDown(){
		int[,] tmp = new int[heightTable, widthTable];
		for (int y = heightTable-1; y>=0; y--) {
			for (int x = 0; x < widthTable; x++) {
				if (y > 0) {
					if (table [y, x] == 2 && (table [y - 1, x] == 1||table[y-1,x]==3)) {
						Replace ();
						return;
					}
				}

				if ((table [y, x] == 1||table[y,x]==3) && y == 19) {
					Replace ();
					return;
				}
				if (y < heightTable-1) {
					if (table [y, x] == 1||table[y,x]==3) {
						tmp [y + 1, x] = table[y,x];
					}
				}
				if (table [y, x] == 2) {
					tmp [y, x] = 2;
				}
			}
		}
		table = tmp;
		figure.AddYCoord ();
	}

	//Фиксируем фигуры на экране
	void Replace (){
		for (int y = 0; y < heightTable; y++) {
			for (int x = 0; x < widthTable; x++) {
				if (table [y, x] >0) {
					table [y, x] = 2;
				}
			}
		}
		CheckLine ();
		AddFigure ();
	}
}
