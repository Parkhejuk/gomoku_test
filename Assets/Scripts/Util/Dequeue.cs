using System.Collections.Generic;

//����ȯ �����Բ��� ģ�� �ϻ��� �ֽ� �ڵ� �ǵ��� ����!!(�߿�)
public class Dequeue<T>
{
    private LinkedList<T> _buf;

    public int Count { get { return _buf.Count; } }

    public Dequeue()
    {
        _buf = new LinkedList<T>();
    }

    public void PushFront(T item)
    {
        _buf.AddFirst(item);
    }

    public void PushBack(T item)
    {
        _buf.AddLast(item);
    }

    public T PopFront()
    {
        if (_buf.Count == 0)
            throw new System.Exception("������ ������ 0��.");
        T first = _buf.First.Value;

        _buf.RemoveFirst();

        return first;
    }

    public T PopBack()
    {
        if (_buf.Count == 0)
            throw new System.Exception("������ ������ 0��.");
        T last = _buf.Last.Value;

        _buf.RemoveLast();

        return last;
    }

    public void Clear() { _buf.Clear(); } //�̰� ���� �߰��� �ڵ�

}