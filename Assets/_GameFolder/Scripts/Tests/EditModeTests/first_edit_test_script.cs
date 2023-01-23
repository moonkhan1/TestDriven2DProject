using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class first_edit_test_script
{
    // Work In Edit Mode
    [Test]
    public void first_edit_test_scriptSimplePasses()
    {
        // Arrange
        // Act
        // Assert
    }
    // Work In Play Mode
    [UnityTest]
    public IEnumerator first_edit_test_scriptWithEnumeratorPasses()
    {
        yield return null;
    }
}
