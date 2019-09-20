#include<iostream>
#include<stdlib.h>

# pragma region 0. Definetion
#define ElemType char
#define STACK_INIT_SIZE 50
#define STACK_INCERMENT 10
using namespace std;

typedef struct BiTNode{
	ElemType data;
	struct BiTNode *lchild, *rchild;
} BiTNode, *BiTree;
# pragma endregion

# pragma region 1. Creation
bool CreateBiTree(BiTree &tree){
	// 按先序顺序输入二叉树的结点值，空格代表空字符
	ElemType data;
	cout << "先序输入字符: ";
	cin >> data;
	if(data == '0')	tree = NULL;
	else{
		if(!(tree = (BiTNode*)malloc(sizeof(BiTNode))))	return false;
		tree->data = data;
		CreateBiTree(tree->lchild);	// 构造左子树
		CreateBiTree(tree->rchild);	// 构造右子树
	}
	return true;
}

/******-构造一个栈，在遍历的时候用-*******/
typedef struct{
	BiTree *base, *top;
	int stackSize;
} SqStack;

bool InitStack(SqStack stack){
	stack.base = (BiTree*)malloc(sizeof(BiTree)*STACK_INIT_SIZE);
	if(stack.base) return false;	// 分配失败
	stack.top = stack.base;
	stack.stackSize = STACK_INIT_SIZE;

	return true;
}

bool Push(SqStack &stack, BiTree &tree){
	if(stack.top - stack.base >= stack.stackSize){
		// 栈满，追加存储空间
		stack.base = (BiTree*)realloc(stack.base, (stack.stackSize + STACK_INCERMENT) * sizeof(BiTree));
		if(!stack.base)	return false;
		stack.top = stack.base + stack.stackSize;
		stack.stackSize += STACK_INCERMENT;
	}
	*stack.top++ = tree;

	return true;
}

bool Pop(SqStack &stack, BiTree &tree){
	if(stack.top == stack.base)	return false;	// 栈空
	tree = *(--stack.top);

	return true;
}

bool StackEmpty(SqStack stack){
	if(stack.top == stack.base)	return true;
	return false;
}

SqStack stack;	// 定义栈头结点
/************--Stack End---*****************/

# pragma endregion

# pragma region 2. Traverse
bool visit(BiTree tree){
	cout << tree->data;
	return true;
}

bool PreOrder(BiTree tree){
	if(!tree)	return false;
	visit(tree);
	PreOrder(tree->lchild);
	PreOrder(tree->rchild);

	return true;
}

bool InOrder(BiTree tree){
	if(!tree)	return false;
	InOrder(tree->lchild);
	visit(tree);
	InOrder(tree->rchild);

	return true;
}

bool PostOrder(BiTree tree){
	if(!tree)	return false;
	PostOrder(tree->lchild);
	PostOrder(tree->rchild);
	visit(tree);

	return true;
}

# pragma endregion

int main(){
	BiTree tree;
	CreateBiTree(tree);
	cout << "二叉树构造完成" << endl;
	cout << "先序遍历: ";
	PreOrder(tree);
	cout << endl << "中序遍历: ";
	InOrder(tree);
	cout << endl << "后序遍历: ";
	PostOrder(tree);

	return 0;
}
