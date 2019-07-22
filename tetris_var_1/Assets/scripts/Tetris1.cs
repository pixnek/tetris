using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


interface IFigure{//интерфейс падающей фигуры
	
	void Figure();//Создает фигуру
	void SetFigure(int [,]tmpFigure);//вызывается при выполнения условий поворота.
	int [,] Rotate();// возвращает повернутую фигуру в описанном квадрате
	int GetSize();//Возвращает размер описанного квадрата
	int [] GetCoord();//Возвращает координаты начала описанного квадрата
	int[,] GetFigure();//Возвращаем описанный квадрат с фигурой
	void AddXCoord();//увеличивает x-координату начала описанного квадрата. Вызывается при успешном выполнении функции MoveRight
	void AddYCoord();// увеличивает y-координату начала описанного квадрата. Вызывается при успешном выполнении функции MoveDown
	void DeductXCoord();// уменьшает x-координату начала описанного квадрата. Вызывается при успешном выполнении функции MoveLeft
}

class kvadrat: IFigure{//фигура квадрат **
					//					**
	int yCoord;
	int xCoord;
	int[,] figure;
	int size;
	public kvadrat(){
		Figure ();
	}
	public void Figure(){
		this.yCoord=0;
		this.xCoord=4;
		this.size = 2;
		this.figure = new int[2,2]{
			{1,3},
			{3,1},
		};
	}
	public void SetFigure(int [,]tmpFigure){
		this.figure = tmpFigure;
	}
	public int [,] Rotate(){
		int[,] tmp=new int[this.size,this.size];
		tmp [0, 0] = figure [0, 1];
		tmp [0, 1] = figure [0, 0];
		tmp [1, 0] = figure [1, 1];
		tmp [1, 1] = figure [1, 0];
		return tmp;
	}
	public int GetSize(){
		return this.size;
	}
	public int [] GetCoord(){
		int []tmp= new int[2];
		tmp [0] = this.yCoord;
		tmp [1] = this.xCoord;
		return tmp;
	}
	public int[,] GetFigure(){
		return this.figure;
	}
	public void AddXCoord(){
		this.xCoord++;
	}
	public void AddYCoord(){
		this.yCoord++;
	}
	public void DeductXCoord(){
		this.xCoord--;
	}
}


class sFigure: IFigure{//фигура **
					//			 **
	int yCoord;
	int xCoord;
	int[,] figure;
	int size;
	public sFigure(){
		Figure ();
	}
	public void Figure(){
		this.yCoord=-1;
		this.size = 3;
		this.figure = new int[3,3]{
			{0,0,0},
			{1,3,0},
			{0,1,3},
		};
		this.xCoord=4;
	}
	public void SetFigure(int [,]tmpFigure){
		this.figure = tmpFigure;
	}
	public int [,] Rotate(){
		int[,] tmp=new int[this.size,this.size];
		for (int y = 0; y < this.size; y++) {
			for (int x = 0; x < this.size; x++) {
				tmp [2 - x, y] = this.figure [y, x];
			}
		}
		return tmp;
	}
	public int GetSize(){
		return this.size;
	}
	public int [] GetCoord(){
		int []tmp= new int[2];
		tmp [0] = this.yCoord;
		tmp [1] = this.xCoord;
		return tmp;
	}
	public int[,] GetFigure(){
		return this.figure;
	}
	public void AddXCoord(){
		this.xCoord++;
	}
	public void AddYCoord(){
		this.yCoord++;
	}
	public void DeductXCoord(){
		this.xCoord--;
	}
}

class sFigureReverse: IFigure{// фигура  **
							//			**
	int yCoord;
	int xCoord;
	int[,] figure;
	int size;
	
	public sFigureReverse(){
		Figure ();
	}
	public void Figure(){
		this.yCoord=-1;
		this.size = 3;
		this.figure = new int[3,3]{
			{0,0,0},
			{0,3,1},
			{3,1,0},
		};
		this.xCoord=4;
	}
	public void SetFigure(int [,]tmpFigure){
		this.figure = tmpFigure;
	}
	public int [,] Rotate(){
		int[,] tmp=new int[this.size,this.size];
		for (int y = 0; y < this.size; y++) {
			for (int x = 0; x < this.size; x++) {
				tmp [2 - x, y] = this.figure [y, x];
			}
		}
		return tmp;
	}
	public int GetSize(){
		return this.size;
	}
	public int [] GetCoord(){
		int []tmp= new int[2];
		tmp [0] = this.yCoord;
		tmp [1] = this.xCoord;
		return tmp;
	}
	public int[,] GetFigure(){
		return this.figure;
	}
	public void AddXCoord(){
		this.xCoord++;
	}
	public void AddYCoord(){
		this.yCoord++;
	}
	public void DeductXCoord(){
		this.xCoord--;
	}
}

class gFigure: IFigure{//фигура буква "Г" на спине    *
			//			   						    ***
	int yCoord;
	int xCoord;
	int[,] figure;
	int size;
	
	public gFigure(){
		Figure ();
	}
	public void Figure(){
		this.yCoord=0;
		this.xCoord=4;
		this.size = 3;
		this.figure = new int[3,3]{
			{0,0,1},
			{3,1,3},
			{0,0,0},
		};
	}
	public void SetFigure(int [,]tmpFigure){
		this.figure = tmpFigure;
	}
	public int [,] Rotate(){
		int[,] tmp=new int[this.size,this.size];
		for (int y = 0; y < this.size; y++) {
			for (int x = 0; x < this.size; x++) {
				tmp [2 - x, y] = this.figure [y, x];
			}
		}
		return tmp;
	}
	public int GetSize(){
		return this.size;
	}
	public int [] GetCoord(){
		int []tmp= new int[2];
		tmp [0] = this.yCoord;
		tmp [1] = this.xCoord;
		return tmp;
	}
	public int[,] GetFigure(){
		return this.figure;
	}
	public void AddXCoord(){
		this.xCoord++;
	}
	public void AddYCoord(){
		this.yCoord++;
	}
	public void DeductXCoord(){
		this.xCoord--;
	}
}

class gFigureReverse: IFigure{//фигура отображенная буква "Г" на спине  *
			//			   											    ***
	int yCoord;
	int xCoord;
	int[,] figure;
	int size;
	
	public gFigureReverse(){
		Figure ();
	}
	public void Figure(){
		this.yCoord=0;
		this.xCoord=4;
		this.size = 3;
		this.figure = new int[3,3]{
			{1,0,0},
			{3,1,3},
			{0,0,0},
		};
	}
	public void SetFigure(int [,]tmpFigure){
		this.figure = tmpFigure;
	}
	public int [,] Rotate(){
		int[,] tmp=new int[this.size,this.size];
		for (int y = 0; y < this.size; y++) {
			for (int x = 0; x < this.size; x++) {
				tmp [2 - x, y] = this.figure [y, x];
			}
		}
		return tmp;
	}
	public int GetSize(){
		return this.size;
	}
	public int [] GetCoord(){
		int []tmp= new int[2];
		tmp [0] = this.yCoord;
		tmp [1] = this.xCoord;
		return tmp;
	}
	public int[,] GetFigure(){
		return this.figure;
	}
	public void AddXCoord(){
		this.xCoord++;
	}
	public void AddYCoord(){
		this.yCoord++;
	}
	public void DeductXCoord(){
		this.xCoord--;
	}
}

class tFigure: IFigure{// Т-образная фигура   *
			//								 ***
	int yCoord;
	int xCoord;
	int[,] figure;
	int size;
	
	public tFigure(){
		Figure ();
	}
	public void Figure(){
		this.yCoord=0;
		this.xCoord=4;
		this.size = 3;
		this.figure = new int[3,3]{
			{0,1,0},
			{1,3,1},
			{0,0,0},
		};
	}
	public void SetFigure(int [,]tmpFigure){
		this.figure = tmpFigure;
	}
	public int [,] Rotate(){
		int[,] tmp=new int[this.size,this.size];
		for (int y = 0; y < this.size; y++) {
			for (int x = 0; x < this.size; x++) {
				tmp [2 - x, y] = this.figure [y, x];
			}
		}
		return tmp;
	}
	public int GetSize(){
		return this.size;
	}
	public int [] GetCoord(){
		int []tmp= new int[2];
		tmp [0] = this.yCoord;
		tmp [1] = this.xCoord;
		return tmp;
	}
	public int[,] GetFigure(){
		return this.figure;
	}
	public void AddXCoord(){
		this.xCoord++;
	}
	public void AddYCoord(){
		this.yCoord++;
	}
	public void DeductXCoord(){
		this.xCoord--;
	}
}

class palochkaFigure: IFigure{//фигура в виде палочки	 ****
	int yCoord;
	int xCoord;
	int[,] figure;
	int size;
	
	public palochkaFigure(){
		Figure ();
	}
	public void Figure(){
		this.xCoord=4;
		this.yCoord=-1;
		this.size = 4;
		this.figure = new int[4,4]{
			{0,0,0,0},
			{3,1,3,1},
			{0,0,0,0},
			{0,0,0,0},
		};
	}
	public void SetFigure(int [,]tmpFigure){
		this.figure = tmpFigure;
	}
	public int [,] Rotate(){
		int[,] tmp=new int[this.size,this.size];
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
		return tmp;
	}
	public int GetSize(){
		return this.size;
	}
	public int [] GetCoord(){
		int []tmp= new int[2];
		tmp [0] = this.yCoord;
		tmp [1] = this.xCoord;
		return tmp;
	}
	public int[,] GetFigure(){
		return this.figure;
	}
	public void AddXCoord(){
		this.xCoord++;
	}
	public void AddYCoord(){
		this.yCoord++;
	}
	public void DeductXCoord(){
		this.xCoord--;
	}
}


public class Tetris1 : MonoBehaviour {

	int [,]table;//сетка игры, где 2 - зафиксированный блок, 3 и 1 - падающая фигура

	Dictionary <int,IFigure> mas = new Dictionary<int,IFigure>();// массив объявлений фигур
	GameObject pfbBlock;//префаб блока, где 1 - темный блок, 2 - свеьлый блок

	Sprite spriteDark;//спрайт темного блока
	Sprite spriteLight;//спрайт светлого блока

	IFigure figure;//объект класса падающей фигуры.

	int widthTable;//ширина игрового поля
	int heightTable;//высота игрового поля

	float []randomValue;//массив значений вероятностей

	GameObject [,] allBlock;//массив блоков


	
	void Fill (){//Заполнение сцены объектами
		allBlock = new GameObject[heightTable, widthTable];
		for (int y = 0; y < heightTable; y++) {
			for (int x = 0; x < widthTable; x++) {
				allBlock [y, x] = GameObject.Instantiate (pfbBlock);
				allBlock [y, x].transform.position = new Vector3 (x,19 - y, 0);
			}
		}
		table = new int[heightTable,widthTable];//инициализация сетки игры
	}

	void Start () {
		heightTable = 20;
		widthTable = 10;
		pfbBlock = Resources.Load<GameObject> ("prefabs/Block");//Подгружаем ресурсы
		spriteDark = Resources.Load<Sprite> ("texture/1");
		spriteLight = Resources.Load<Sprite> ("texture/2");
		
		mas[1] = new kvadrat ();
		mas[2] = new sFigure();
		mas[3] = new sFigureReverse();
		mas[4] = new gFigure();
		mas[5] = new gFigureReverse();
		mas[6] = new palochkaFigure();
		mas[7] = new tFigure();
		randomValue = new float []{0.1f,0.15f,0.15f,0.15f,0.15f,0.1f,0.2f,};
		Fill ();
		AddFigure ();
		Draw ();
		InvokeRepeating ("MoveDown", 1, 0.3f);
	}

	//Поворот фигуры
	void Rotate(){
		int[,] tmpFigure = figure.Rotate ();
		int size = figure.GetSize ();
		int[] coord = figure.GetCoord ();
		int[,] tmpTable = new int[size, size];

		for (int y = coord [0]; y < coord [0] + size; y++) {
			for (int x = coord [1]; x < coord [1] + size; x++) {
				if ((y >= 0) && (y < heightTable) && (x >= 0) && (x < widthTable)) {
					tmpTable [y - coord [0], x - coord [1]] = table [y, x];
					if (table [y, x] == 2) {
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
				if ((y >= 0) && (y < heightTable) && (x >= 0) && (x < widthTable)) {
					table [y, x] = tmpFigure [y - coord [0], x - coord [1]];
				}
			}
		}
		figure.SetFigure (tmpFigure);
	}

	//Добавлене фигуры
	void AddFigure(){
		int n = RandomFigure ();
		figure = mas[n];
		figure.Figure ();
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
		for (int y = heightTable-1; y >=0; y--) {
			int sum = 0;
			for (int x = 0; x < widthTable; x++) {
				sum = sum + table [y, x];
			}
			if (sum == 2*widthTable) {
				CleanLine (y);
				y++;
			}
		}
	}

	//Движение вправо
	void MoveRight(){
		int [,]tmp=new int[heightTable,widthTable];
		for (int y = 0; y < heightTable; y++) {
			for (int x = 0; x < widthTable; x++) {
				if (table [y, x] == 1 || table [y, x] == 3) {
					if (x == widthTable-1) {
						return;
					}
					if (table [y, x + 1] == 2) {
						return;
					}
					tmp [y, x + 1] = table [y, x];
				}
				if (table [y, x] == 2) {
					tmp [y, x] = 2;
				}
			}
		}
		table = tmp;
		figure.AddXCoord ();
	}

	//Движение влево
	void MoveLeft(){
		int [,]tmp=new int[heightTable,widthTable];
		for (int y = 0; y < heightTable; y++) {
			for (int x = 0; x < widthTable; x++) {
				if (table [y, x] == 1 || table [y, x] == 3) {
					if (x == 0) {
						return;
					}
					if (table [y, x - 1] == 2) {
						return;
					}
					tmp [y, x - 1] = table [y, x];
				}
				if (table [y, x] == 2) {
					tmp [y, x] = 2;
				}
			}
		}
		table = tmp;
		figure.DeductXCoord ();
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
