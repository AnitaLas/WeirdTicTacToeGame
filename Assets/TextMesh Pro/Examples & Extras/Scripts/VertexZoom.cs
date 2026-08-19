using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TMPro.Examples
{
    public class VertexZoom : MonoBehaviour
    {
        public float AngleMultiplier = 1.0f;
        public float SpeedMultiplier = 1.0f;
        public float CurveScale = 1.0f;

        private TMP_Text m_TextComponent;
        private bool hasTextChanged;

        void Awake()
        {
            m_TextComponent = GetComponent<TMP_Text>();
        }

        void OnEnable()
        {
            TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
        }

        void OnDisable()
        {
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
        }

        void Start()
        {
            StartCoroutine(AnimateVertexColors());
        }

        void ON_TEXT_CHANGED(Object obj)
        {
            if (obj == m_TextComponent)
                hasTextChanged = true;
        }

        IEnumerator AnimateVertexColors()
        {
            m_TextComponent.ForceMeshUpdate();

            TMP_TextInfo textInfo = m_TextComponent.textInfo;

            Matrix4x4 matrix;

            TMP_MeshInfo[] cachedMeshInfoVertexData =
                textInfo.CopyMeshInfoVertexData();

            List<float> modifiedCharScale = new List<float>();
            List<int> scaleSortingOrder = new List<int>();

            hasTextChanged = true;

            while (true)
            {
                if (hasTextChanged)
                {
                    cachedMeshInfoVertexData =
                        textInfo.CopyMeshInfoVertexData();

                    hasTextChanged = false;
                }

                int characterCount = textInfo.characterCount;

                if (characterCount == 0)
                {
                    yield return new WaitForSeconds(0.25f);
                    continue;
                }

                modifiedCharScale.Clear();
                scaleSortingOrder.Clear();

                for (int i = 0; i < characterCount; i++)
                {
                    TMP_CharacterInfo charInfo =
                        textInfo.characterInfo[i];

                    if (!charInfo.isVisible)
                        continue;

                    int materialIndex =
                        charInfo.materialReferenceIndex;

                    int vertexIndex =
                        charInfo.vertexIndex;

                    Vector3[] sourceVertices =
                        cachedMeshInfoVertexData[materialIndex].vertices;

                    Vector3 charMidBaseline =
                        (sourceVertices[vertexIndex] +
                         sourceVertices[vertexIndex + 2]) / 2f;

                    Vector3 offset = charMidBaseline;

                    Vector3[] destinationVertices =
                        textInfo.meshInfo[materialIndex].vertices;

                    destinationVertices[vertexIndex] =
                        sourceVertices[vertexIndex] - offset;

                    destinationVertices[vertexIndex + 1] =
                        sourceVertices[vertexIndex + 1] - offset;

                    destinationVertices[vertexIndex + 2] =
                        sourceVertices[vertexIndex + 2] - offset;

                    destinationVertices[vertexIndex + 3] =
                        sourceVertices[vertexIndex + 3] - offset;

                    float randomScale =
                        Random.Range(1f, 1.5f);

                    modifiedCharScale.Add(randomScale);
                    scaleSortingOrder.Add(
                        modifiedCharScale.Count - 1
                    );

                    matrix = Matrix4x4.TRS(
                        Vector3.zero,
                        Quaternion.identity,
                        Vector3.one * randomScale
                    );

                    destinationVertices[vertexIndex] =
                        matrix.MultiplyPoint3x4(
                            destinationVertices[vertexIndex]
                        );

                    destinationVertices[vertexIndex + 1] =
                        matrix.MultiplyPoint3x4(
                            destinationVertices[vertexIndex + 1]
                        );

                    destinationVertices[vertexIndex + 2] =
                        matrix.MultiplyPoint3x4(
                            destinationVertices[vertexIndex + 2]
                        );

                    destinationVertices[vertexIndex + 3] =
                        matrix.MultiplyPoint3x4(
                            destinationVertices[vertexIndex + 3]
                        );

                    destinationVertices[vertexIndex] += offset;
                    destinationVertices[vertexIndex + 1] += offset;
                    destinationVertices[vertexIndex + 2] += offset;
                    destinationVertices[vertexIndex + 3] += offset;

                    Vector4[] sourceUVs =
                        cachedMeshInfoVertexData[materialIndex].uvs0;

                    Vector4[] destinationUVs =
                        textInfo.meshInfo[materialIndex].uvs0;

                    destinationUVs[vertexIndex] =
                        sourceUVs[vertexIndex];

                    destinationUVs[vertexIndex + 1] =
                        sourceUVs[vertexIndex + 1];

                    destinationUVs[vertexIndex + 2] =
                        sourceUVs[vertexIndex + 2];

                    destinationUVs[vertexIndex + 3] =
                        sourceUVs[vertexIndex + 3];

                    Color32[] sourceColors =
                        cachedMeshInfoVertexData[materialIndex].colors32;

                    Color32[] destinationColors =
                        textInfo.meshInfo[materialIndex].colors32;

                    destinationColors[vertexIndex] =
                        sourceColors[vertexIndex];

                    destinationColors[vertexIndex + 1] =
                        sourceColors[vertexIndex + 1];

                    destinationColors[vertexIndex + 2] =
                        sourceColors[vertexIndex + 2];

                    destinationColors[vertexIndex + 3] =
                        sourceColors[vertexIndex + 3];
                }

                for (int i = 0;
                     i < textInfo.meshInfo.Length;
                     i++)
                {
                    if (textInfo.meshInfo[i].vertices == null)
                        continue;

                    textInfo.meshInfo[i].SortGeometry(
                        scaleSortingOrder
                    );

                    textInfo.meshInfo[i].mesh.vertices =
                        textInfo.meshInfo[i].vertices;

                    textInfo.meshInfo[i].mesh.colors32 =
                        textInfo.meshInfo[i].colors32;

                    m_TextComponent.UpdateGeometry(
                        textInfo.meshInfo[i].mesh,
                        i
                    );
                }

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}