using NUnit.Framework;

using System;


namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void SetUp()
    {
        this._article = new Article();
    }

    // TODO: finish test
    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articleData =
        {
            "Article Content Author",
            "Article2 Content2 Author3",
            "Article3 Content2 Author3",
        };
        // Act
        Article result = this._article.AddArticles(articleData);
        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        //Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
               new Article()
             {
                    Author = "Denis",
                    Content = "Comedy",
                    Title = "Programming"
              },
                new Article()
                {
                    Author = "Ivan",
                    Content = "Tragedy",
                    Title = "SoftUni"
                }
            }
        };
        string expected = $"Programming - Comedy: Denis{Environment.NewLine}SoftUni - Tragedy: Ivan";
        //Act
        string result = this._article.GetArticleList(inputArticle, "title");
        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        //Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
               new Article()
             {
                    Author = "Denis",
                    Content = "Comedy",
                    Title = "Programming"
              },
                new Article()
                {
                    Author = "Ivan",
                    Content = "Tragedy",
                    Title = "SoftUni"
                }
            }
        };

        //Act
        string result = this._article.GetArticleList(inputArticle, "no-criteria");
        //Assert
        Assert.AreEqual(string.Empty, result);
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenArticleHasNoArticlesInItsList()
    {
        Article inputArticle = new Article()
        {
            ArticleList = new()
        };

        //Act
        string actual = this._article.GetArticleList(inputArticle, "title");
        //Assert
        Assert.AreEqual(string.Empty, actual);
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByAuthor()
    {
        //Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
               new Article()
             {
                    Author = "Denis",
                    Content = "Comedy",
                    Title = "Programming"
              },
                new Article()
                {
                    Author = "Ivan",
                    Content = "Tragedy",
                    Title = "SoftUni"
                }
            }
        };
        string expected = $"Programming - Comedy: Denis{Environment.NewLine}SoftUni - Tragedy: Ivan";
        //Act
        string result = this._article.GetArticleList(inputArticle, "author");
        //Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByContent()
    {
        //Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
               new Article()
             {
                    Author = "Denis",
                    Content = "Comedy",
                    Title = "Programming"
              },
                new Article()
                {
                    Author = "Ivan",
                    Content = "Tragedy",
                    Title = "SoftUni"
                }
            }
        };
        string expected = $"Programming - Comedy: Denis{Environment.NewLine}SoftUni - Tragedy: Ivan";
        //Act
        string result = this._article.GetArticleList(inputArticle, "content");
        //Assert
        Assert.AreEqual(expected, result);

    }
}
