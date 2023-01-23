using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class play_test_script
{
     // Work In Edit Mode
    [Test]
    public void play_test_scriptSimplePasses()
    {
    }

    // Work In Play Mode
    [UnityTest]
    public IEnumerator play_test_scriptWithEnumeratorPasses()
    {

        yield return null;
    }
}
