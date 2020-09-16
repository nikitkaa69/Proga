#include <iostream>
#include "Lab10.h"
#include <cmath>
node* createNode(int x)
{
	node *p = new node;
	p->num = x;
	p->right = p->left = nullptr;
	return p;
}

//	========================
//	||		  Tree		  ||
//	========================

Tree::Tree()
{ 
	root = nullptr;
	iMax = 0;
	Max = INT_MIN;
	tSize = 0;
	size = 0;

	for (int i = 0; i < 30; i++)
	{
		tariffs[i].users = 0;
	}
}
Tree::~Tree()
{
	delete root;
}
int Tree::getSize()
{
	return size;
}

void Tree::add(int x)
{
	size++;
	if (root)
	{
		root->add(x);
	}
	else
	{
		root = createNode(x);
	}
}

void Tree::dfprint()
{
	if (root)
	{
		printf("Дерево:\n---------------\n");
		root->dfprint(root);
		printf("---------------\n");
	}
}

void Tree::sort()
{
	if (root)
	{
		printf("Отсортированный массив:\n---------------\n");
		root->sort(root->left);
		printf("%d\n", root->num);
		root->sort(root->right);
		printf("---------------\n");
	}
}

void Tree::multiInput()
{
	while (1)
	{
		char str[50];
		printf("Введите число (любой символ для выхода):");
		scanf_s("%s", str, 50);
		if (!check(str)) break; // Является ли введёное выражение числом
		int x = atof(str);
		this->add(x);
	}
}

node* Tree::dfs(int x)
{
	if (root)
	{
		if (x == root->num)
		{
			return root;
		}
		else
			root->dfs(x);
	}
}

node* Tree::dfs(int x, node *&parent)
{
	parent = nullptr; // если искомый элемент - корень, то родительского элемента нет
	if (root)
	{
		if (x == root->num)
		{
			return root;
		}
		else
			root->dfs(x, parent);
	}
}


void Tree::del(node *&toDel, node *&parent)
{
	size--;
	
	if (root)
	{
		if (root!= toDel)
		{
			if (parent)
				delNode(toDel, parent);
			else
			{
				parent = new node;
				parent->right = toDel;
				delNode(toDel, parent);
			}
		}
		else
		{

			// Смотреть функцию nodeDelete
			node *&p = root;
			if (p->left == NULL && p->right == NULL)
			{
				p = NULL;
				return;
			}
			if (p->left != NULL && p->right == NULL)
			{
				*p = *(p->left);
				return;
			}
			if (p->left == NULL && p->right != NULL)
			{
				*p = *(p->right);
				return;
			}
			if (p->left != NULL && p->right != NULL)
			{
				//node **q = &p; // Deja vu, i've just been in this place before

				if (!p->right->left) // если у правого элемента нет левого узла
				{
					p->right->left = p->left;
					p = p->right;
				}
				else
				{
					p->num = p->right->left->num;
					delNode(p->right->left, p->right);
				}

			}
		}
	}

}

bool Tree::balanced()
{
	std::cout << "\n" << root->left->balanced()-1;
	std::cout << "\n" << root->right->balanced()-1 << "\n";
	if (abs(root->left->balanced() - root->right->balanced() ) > 1)
		return false;
	else
		return true;
}

//	========================
//	||		  node		  ||
//	========================

void node::add(int x)
{
	node **next;

	if (x < num)
	{
		next = &left;
	}
	else
	{
		next = &right;
	}

	if (*next)
	{
		node *temp = *next;
		temp->add(x);
	}
	else
	{
		*next = createNode(x);
	}

	
}


void node::dfprint(node *p)
{
	if (p)
	{
		dfprint(p->left);
		dfprint(p->right);
		printf("%d\n", p->num);
	}
}

void node::sort(node *p)
{
	if (p)
	{
		sort(p->left);
		printf("%d\n", p->num);
		sort(p->right);
	}
	else return;
}

node* node::dfs(int x)
{
	if (this)
	{
		if (x == this->num)
		{
			return this;
		}
		else
		{
			node *p;
			p = this->left->dfs(x);
			if (p)
				return p;

			p = this->right->dfs(x);

			if (p)
				return p;


		}
	}
	else
		return nullptr;
}

node* node::dfs(int x, node *&parent)
{
	if (this)
	{
		if (x == this->num)
		{
			return this;
		}
		else
		{
			node *p;
			parent = this;
			if (x < this->num)
			{
				p = this->left->dfs(x, parent);
			}
			else
			{
				p = this->right->dfs(x, parent);
			}
/*			
			p = this->left->dfs(x, parent);
			if (p)
				return p;

			p = this->right->dfs(x, parent);

			if (p)
				return p;
				*/

		}
	}
	else
		return nullptr;
}
int node::balanced()
{
	if (!this)
	{
		return 1;
	}
	else
	{
		return std::fmaxl(this->left->balanced(), this->right->balanced()) + 1;
	}
}
void delNode(node *&p, node *&parent) // не работает с корнем!
{
	node **toDel;
	if (!parent) // Если родительского элемента не сущесвует, то извращения не нужны (нужны :C). 
				//	На самом деле это условие более не нужно и проверяется в методе для tree, но мне немного лень убирать.
	{
		toDel = &(parent->right);
	}
	else // Иначе вместо p используется указатель на p через родителя, чтобы изменения отражались на дереве
	{
		if (parent->left == p)
		{
			toDel = &(parent->left);
		}
		else
		{
			toDel = &(parent->right);
		}
	}
	if (p->left == NULL && p->right == NULL)
	{
		*toDel =  NULL;
		return;
	}
	if (p->left != NULL && p->right == NULL)
	{
		*p = *(p->left);
		return;
	}
	if (p->left == NULL && p->right != NULL)
	{
		*p = *(p->right);
		return;
	}
	if (p->left != NULL && p->right != NULL)
	{
		//node **q = &p; // Deja vu, i've just been in this place before
		
		if (!p->right->left) // если у правого элемента нет левого узла
		{
			p->right->left = p->left;
			*toDel = p->right;
		}
		else
		{
			p->num = p->right->left->num;
			delNode(p->right->left, p->right);
		}

	}

	
}

//	========================
//	||		 Задания	  ||
//	========================

int Tree::osn1()
{
	return root->left->osn1() - 1;
}

int Tree::dop2()
{
	return root->right->osn1() - 1;
}

int node::osn1() 
{
	if (this)
	{
		return this->left->osn1() + this->right->osn1();
	}
	else
		return 1;
}



int Tree::dop16()
{
	if (root)
		return root->dop16();
	else
		return 0;
}

int node::dop16()
{
	int a = 0, b = 0;
	if (left)
		a = left->dop16();

	if (right)
		b = right->dop16();

	return num + a + b;
}

//	==============================
//	||			LAB 12			||
//	==============================

void Tree::adduns(int x)
{
	if (!root)
	{
		root = createNode(x);
	}
	else
	{
		node *p = root; 
		while (p->left && p->right)
		{
			p = p->right;
		}

		if (!p->left)
		{
			p->left = createNode(x);
		}
		else
		{
			p->right = createNode(x);
		}

	}
}

node* createNodeMob(int x, char* tariff)
{
	node *p = new node;
	p->num = x;
	p->tariff = tariff;
	p->right = p->left = nullptr;
	return p;
}

void Tree::addMob(int x, char* tariff)
{
	bool flag = false;
	size++;

	for (int i = 0; i < tSize; i++)
	{

		if (tariffs[i].tariff == tariff)
		{
			flag = true;
			tariffs[i].users++;

			if (tariffs[i].users > Max)
			{
				Max = tariffs[i].users;
				iMax = i;
			}
			break;
		}

	}

	if (!flag) // такого тарифа ранее не было
	{
		tariffs[tSize].tariff = tariff;
		tariffs[tSize].users = 1;

		if (tariffs[tSize].users > Max)
		{
			Max = tariffs[tSize].users;
			iMax = tSize;
		}
		tSize++;

	}


	if (root)
	{
		root->addMob(x, tariff);
	}
	else
	{
		root = createNodeMob(x, tariff);
	}
}

void node::addMob(int x, char* tariff)
{
	node **next;

	if (x < num)
	{
		next = &left;
	}
	else
	{
		next = &right;
	}

	if (*next)
	{
		node *temp = *next;
		temp->addMob(x, tariff);
	}
	else
	{
		*next = createNodeMob(x, tariff);
	}

}

char* Tree::findMax()
{
	return tariffs[iMax].tariff;
}