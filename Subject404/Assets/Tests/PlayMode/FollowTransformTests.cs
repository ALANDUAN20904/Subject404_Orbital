using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FollowTransformTests
{
    private GameObject gameObject;
    private GameObject mainCamera;
    private FollowTransform followTransform;

    [SetUp]
    public void SetUp()
    {
        gameObject = new GameObject("TestObject");
        mainCamera = new GameObject("MainCamera");
        mainCamera.AddComponent<Camera>();
        mainCamera.tag = "MainCamera";
        followTransform = gameObject.AddComponent<FollowTransform>();
    }

    [UnityTest]
    public IEnumerator FollowsMainCamera()
    {
        mainCamera.transform.position = new Vector3(11, 26, 300);
        mainCamera.transform.rotation = Quaternion.Euler(45, 90, 72);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        Assert.AreEqual(mainCamera.transform.position, gameObject.transform.position);
        Assert.AreEqual(mainCamera.transform.rotation, gameObject.transform.rotation);
    }
}