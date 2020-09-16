#pragma once

struct node
{
	int num;
	node *left;
	node *right;

	char* tariff;

	void add(int x);
	void dfprint(node *p);
	node* dfs(int x);
	node* dfs(int x, node *&parent);
	//void bfprint(node *p);
	int balanced();
	
	void sort(node *p);


	// Задания
	int osn1();
	int dop16();

	// LAB12
	void addMob(int x, char* tariff);

};

class Tree
{
private:
	node *root;
	int size;
	
	struct tar
	{
		char *tariff;
		int users;
	} tariffs[30];

	int tSize;
	int iMax;
	int Max;
public:
	Tree();
	~Tree();
	
	int getSize();
	void add(int x);
	void dfprint();		// depth-first-print 
	//void bfprint();	// breadth-first-print
	void multiInput();
	void sort();
	node* dfs(int x);	// depth-first-search
	node* dfs(int x, node *&parent);	// depth-first-search, записыывает родительский элемент во второй аргумент
	void del(node *&toDel, node *&parent);
	bool balanced();

	
	// Задания
	int osn1();
	int dop2();
	int dop16();

	// LAB12
	
	void adduns(int x);

	void addMob(int x, char *tariff);
	char* findMax();

};

node* createNode(int x);
void delNode(node *&p,node *&parent);


bool check(char str[]);