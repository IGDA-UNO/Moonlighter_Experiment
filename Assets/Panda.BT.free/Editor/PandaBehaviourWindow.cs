/*
Copyright (c) 2015 Eric Begue (ericbeg@gmail.com)

This source file is part of the Panda BT package, which is licensed under
the Unity's standard Unity Asset Store End User License Agreement ("Unity-EULA").

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using UnityEngine;
using UnityEditor;

using System.Collections;
using Panda;

public class PandaBehaviourWindow : EditorWindow
{
    [MenuItem("Window/Panda Behaviour")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        PandaBehaviourWindow window = (PandaBehaviourWindow)EditorWindow.GetWindow(typeof(PandaBehaviourWindow));
        window.Show();
    }

    void OnGUI()
    {

        EditorGUILayout.BeginVertical();
        /*
        // static
        BTLSyntaxHighlight.keywordColor = EditorGUILayout.ColorField("keyword", BTLSyntaxHighlight.keywordColor);
        BTLSyntaxHighlight.commentColor = EditorGUILayout.ColorField("comment", BTLSyntaxHighlight.commentColor);
        BTLSyntaxHighlight.valueColor =EditorGUILayout.ColorField("value", BTLSyntaxHighlight.valueColor);
        BTLSyntaxHighlight.taskColor =EditorGUILayout.ColorField("task", BTLSyntaxHighlight.taskColor);

        // liveview
        BTLSyntaxHighlight.readyColor = EditorGUILayout.ColorField("ready", BTLSyntaxHighlight.readyColor);
        BTLSyntaxHighlight.failedColor = EditorGUILayout.ColorField("failed", BTLSyntaxHighlight.failedColor);
        BTLSyntaxHighlight.succeededColor =EditorGUILayout.ColorField("succeeded", BTLSyntaxHighlight.succeededColor);
        BTLSyntaxHighlight.runningColor = EditorGUILayout.ColorField("running", BTLSyntaxHighlight.runningColor);
        */
        EditorGUILayout.EndVertical();
    }
}