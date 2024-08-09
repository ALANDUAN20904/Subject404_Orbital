using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnableGameObjectOnTriggerTests
{
    private GameObject testManager;
    private EnableGameObjectOnTrigger enablerComponent;
    private GameObject objectToEnable;
    private BoxCollider collider;

    [SetUp]
    public void SetUp()
    {
        testManager = new GameObject();
        enablerComponent = testManager.AddComponent<EnableGameObjectOnTrigger>();
        objectToEnable = new GameObject();
        objectToEnable.SetActive(false);
        collider = testManager.AddComponent<BoxCollider>();
    }
    [Test]
    public void EnablesGameObjectOnTriggerEnterTest()
    {
        enablerComponent.objectToEnable = objectToEnable;
        enablerComponent.OnTriggerEnter(collider);
        Assert.IsTrue(objectToEnable.activeSelf);
    }

    [Test]
    public void ThrowsErrorNoObjectTest()
    {
        LogAssert.Expect(LogType.Error, "Object to enable not set");
        enablerComponent.OnTriggerEnter(collider);
        LogAssert.NoUnexpectedReceived();
    }
}
