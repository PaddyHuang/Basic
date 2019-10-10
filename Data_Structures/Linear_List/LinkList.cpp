#include <iostream>

#pragma region 0. Definition
#define ElemType int
typedef struct LNode{
    ElemType data;
    struct LNode *next;
} LNode, *LinkList;
#pragma endregion

#pragma region 1. Creation
// 1.1 Create list by head
LinkList CreateListHead(LinkList &list){
    LNode *s;
    ElemType x;
    list = (LinkList)malloc(sizeof(LNode));
    list->next = NULL;

    std::cout << "Enter list: " << std::endl;
    std::cout << "Enter 9999 to end" << std::endl;
    std::cin >> x;
    while (x != 9999)
    {
        s = (LNode*)malloc(sizeof(LNode));
        s->data = x;
        s->next = list->next;
        list->next = s;
        std::cout << "Enter list: " << std::endl;
        std::cin >> x;
    }
    return list;
}

// 1.2 Create list by rear
LinkList CreateListRear(LinkList &list){
    // LNode *s, *r = list;        // list尚未赋予空间，不能作为给变量赋值
    ElemType x;
    list = (LinkList)malloc(sizeof(LNode));
    LNode *s, *r = list;
    list->next = NULL;

    std::cout << "Enter list: " << std::endl;
    std::cout << "Enter 9999 to end" << std::endl;
    std::cin >> x;
    while (x != 9999)
    {
        s = (LNode*)malloc(sizeof(LNode));
        s->data = x;
        r->next =s;
        r = s;
        std::cout << "Enter list: " << std::endl;
        std::cin >> x;
    }
    r->next = NULL;
    return list;
}
#pragma endregion

#pragma region 2. GetLength
int GetLength(LinkList list){
    int counter = 0;
    LNode *p = list->next;
    while (p != NULL){
        counter++;
        p = p->next;
    }
    return counter;
}
#pragma endregion

#pragma region 3. Locate Elem
LNode* LocateELem(LinkList list, ElemType e){
    LNode *p = list->next;
    while(p != NULL && p->data != e)
        p = p->next;
    return p;
}
#pragma endregion

#pragma region 4. Get Elem
LNode* GetElem(LinkList list, int i){
    int counter = 1;
    LNode *p = list->next;
    
    if(i == 0)
        return list;
    if(i < 0)
        return NULL;
    
    while(p && counter < i){
        p = p->next;
        counter++;
    }
    return p;
}
#pragma endregion

#pragma region 5. Insert Elem
// 5.1 Backward
bool InsertElemBackward(LinkList &list, int i, ElemType e){
    if(i < 0 || i > GetLength(list) + 1)
        return false;
    
    LNode *p, *s = (LNode*)malloc(sizeof(LNode));
    s->data = e;
    p = GetElem(list, i - 1);
    s->next = p->next;
    p->next = s;

    return true;
}
// 5.2 Forward
bool InsertELemForward(LinkList &list, int i, ElemType e){
    if(i < 0 || i > GetLength(list) + 1)
        return false;
    
    LNode *p, *s = (LNode*)malloc(sizeof(LNode));
    s->data = e;
    p = GetElem(list, i - 1);
    s->next = p->next;
    p->next = s;

    int temp = s->data;
    s->data = p->data;
    p->data = temp;

    return true;
}
#pragma endregion

#pragma region 6. Delete Elem
bool DeleteElem(LinkList &list, int i){
    if(i < 0 || i > GetLength(list) + 1)
        return false;
    
    LNode *p = GetElem(list, i - 1);
    LNode *q = p->next;
    p->next = q->next;
    free(q);
    return true;
}
#pragma endregion

#pragma region 7. Print list
void PrintList(LinkList list){
    LNode *p = list->next;
    while (p != NULL)
    {
        std::cout << p->data <<std::endl; 
        p = p->next;            // 漏加这一句导致死循环报错
    }
}
#pragma endregion

#pragma region 8. Empty
bool Empty(LinkList list){
    if(list->next == NULL)
        return true;
    return false;
}
#pragma endregion

#pragma region 9. Destroy list
void Destroylist(LinkList &list){
    free(list);
    list->next = NULL;
}

int main(){
    // 1. Creation
    // !.1 Head
    // LinkList list = CreateListHead(list);
    // 1.2 Rear
    LinkList list = CreateListRear(list);

    // 2. GetLength
    std::cout << "Length: " << GetLength(list) << std::endl;

    // 3. Locate Elem 
    std::cout << "Located node: " << LocateELem(list, 2)->data << std::endl;

    // 4. Get Elem
    std::cout << "Got node: " << GetElem(list, 3)->data << std::endl;

    // 5.1 Insert ELem Backward
    if(InsertElemBackward(list, 1, 666))
        std::cout << "Insesrt Elem Backward: " << GetElem(list, 1)->data << std::endl; 
    else
        std::cout << "Insert Failed!" << std::endl;
    
    // 5.2 Insert Elem Forward
    if(InsertELemForward(list, 2, 777))
        std::cout << "Insesrt Elem Forward: " << GetElem(list, 3)->data << std::endl; 
    else
        std::cout << "Insert Failed!" << std::endl;

    // 6. Delete ELem
    PrintList(list);
    if(DeleteElem(list, 1))
        PrintList(list);
    else
        std::cout << "Insert Failed!" << std::endl;

    // 7. Print list
    PrintList(list);

    // 8.Empty
    std::cout << "Empty list? " << Empty(list) << std::endl;
    
    // 9. Destroy list
    Destroylist(list);
    std::cout << "Empty list? " << Empty(list) << std::endl;

    return 0;
}
