using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Net;

namespace TestApp.UnitTests;

public class PersonTests
{
    private Person _person;

    [SetUp]
    public void setup()
    {
        this._person = new Person();
    }

    // TODO: finish test
    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        //Arrange
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 35" };
        List<Person> expectedPeopleList = new()
        {
            new Person
            {
                Name = "Alice",
                Id = "A001",
                Age = 35
            },
            new Person
            {
                Name = "Bob",
                Id = "B002",
                Age = 30
            }
        };

        //Act
        List<Person> resultPeopleList = this._person.AddPeople(peopleData);

        //Assert
        Assert.That(resultPeopleList, Has.Count.EqualTo(2));
        for (int i = 0; i < resultPeopleList.Count; i++)
        {
            Assert.That(resultPeopleList[i].Name, Is.EqualTo(expectedPeopleList[i].Name));
            Assert.That(resultPeopleList[i].Id, Is.EqualTo(expectedPeopleList[i].Id));
            Assert.That(resultPeopleList[i].Age, Is.EqualTo(expectedPeopleList[i].Age));
        }
    }
    [Test]
    public void Test_AddPeople_ReturnsListWhenNoDataIsGiven()
    {
        //Arrange
        string[] peopleData = { };
        //Act
        List<Person> result = this._person.AddPeople(peopleData);
        //Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        //Arrange
        List<Person> people = new()
        {
            new Person
            {
                Name = "Denis",
                Id = "005",
                Age = 30
            },
            new Person
            {
                Name = "Yoko",
                Id = "007",
                Age = 8
            },
            new Person
            {
                Name = "Cveti",
                Id = "001",
                Age = 50
            }
        };
        string expected = 
            $"Yoko with ID: 007 is 8 years old.{Environment.NewLine}" +
            $"Denis with ID: 005 is 30 years old.{Environment.NewLine}" +
            $"Cveti with ID: 001 is 50 years old.";
        //Act
        string result = this._person.GetByAgeAscending(people);
        //Assert
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void Test_GetByAgeAscending_ReturnEmptyString_WhenNoDataIsGiven()
    {
        //Arrange
        List<Person> people = new List<Person>();
        //Act
        string actual = this._person.GetByAgeAscending(people);
        //Assert
        Assert.AreEqual(string.Empty, actual);
    }
}
