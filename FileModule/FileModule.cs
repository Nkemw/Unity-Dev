using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class FileWriter
{
    protected string filePath;

    public FileWriter(string filePath)
    {
        this.filePath = filePath;
    }

    public abstract void WriteData(object data);

    public static FileWriter CreateWriter(string filePath)
    {
        //������ Ȯ���ڰ� .json���� Ȯ���Ͽ� Ȯ���ڿ� �´� ������ ����
        //.json Ȯ���ڰ� �ƴ� ���ϵ��� ��� TextfileWriter�� ����ǹǷ�
        //TextFileWriter�� �ǹ̰� ��ȣ��
        if (filePath.EndsWith(".json"))
        {
            return new JsonFileWriter(filePath);
        }
        else
        {
            return new TextFileWriter(filePath);
        }
    }
}

public class JsonFileWriter : FileWriter
{
    //���� ��θ� �޾� �θ� Ŭ������ FileWriter�� ������ ����
    public JsonFileWriter(string filePath) : base(filePath) { }

    public override void WriteData(object data)
    {
        string json = JsonUtility.ToJson(data);     //Json�������� ��ȯ�� �� ���� ����
        Debug.Log(json);
        File.WriteAllText(filePath, json);
    }
}

public class TextFileWriter : FileWriter
{
    public TextFileWriter(string filePath) : base(filePath) { }

    public override void WriteData(object data)
    {
        string text = data.ToString();              //���ڿ��� ��ȯ�� �� ���� ����
        File.WriteAllText(filePath, text);
    }
}

public abstract class FileReader
{
    protected string filePath;

    public FileReader(string filePath)
    {
        this.filePath = filePath;
    }

    public abstract T ReadData<T>(); //��ü�� Ÿ������ ������ �ҷ����� �̸� ��ȯ

    public static FileReader CreateReader(string filePath)
    {
        if (filePath.EndsWith(".json"))
        {
            return new JsonFileReader(filePath);
        }
        else
        {
            return new TextFileReader(filePath);
        }
    }
}

public class JsonFileReader : FileReader
{
    public JsonFileReader(string filePath) : base(filePath) { }

    public override T ReadData<T>()
    {
        T data = JsonUtility.FromJson<T>(File.ReadAllText(filePath));
        return data;
    }
}

public class TextFileReader : FileReader
{
    public TextFileReader(string filePath) : base(filePath) { }

    public override T ReadData<T>()
    {
        T data = JsonUtility.FromJson<T>(File.ReadAllText(filePath));
        return data;
    }
}


public class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}

public class FileModule : MonoBehaviour
{
    private void Awake()
    {
        string filePath = Application.persistentDataPath + "/data.json";

        //���� ��� Ȯ��
        Debug.Log(filePath);

        FileWriter writer = FileWriter.CreateWriter(filePath);
        FileReader reader = FileReader.CreateReader(filePath);

        // �� ������ ����
        Person savePeople = new Person("Alice", 25);

        // ������ ����
        writer.WriteData(savePeople);

        Person loadPeople = reader.ReadData<Person>();

        Debug.Log("�ҷ��� ����� �̸�: " + loadPeople.name +
                    " �ҷ��� ����� ����: " + loadPeople.age);

    }
}
