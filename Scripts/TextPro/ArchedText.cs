using UnityEngine;
using TMPro;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class ArchedText : MonoBehaviour
{
	public enum TextVAlignment
	{
		Base,
		Top,
		Bottom,
	}

	[SerializeField]
	private TextVAlignment vAlignment;
	[SerializeField]
	private TextAlignment hAlignment;
	[SerializeField]
	private AnimationCurve vertexCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 0.25f), new Keyframe(1, 0f));

	private TMP_Text textComponent;

	void Awake()
	{
		textComponent = gameObject.GetComponent<TMP_Text>();
	}

	void Update()
	{
		if (!textComponent.havePropertiesChanged)
		{
			return;
		}

		UpdateCurveMesh();
	}

	void UpdateCurveMesh()
	{
		textComponent.ForceMeshUpdate();

		TMP_TextInfo textInfo = textComponent.textInfo;
		int characterCount = textInfo.characterCount;

		if (characterCount == 0)
			return;

		Vector3 baseline = new Vector3();
		Vector3 prevAngleDirection = new Vector3();
		Vector3 prevOffsetToMidBaseline = new Vector3();
		Vector3[] vertices;
		Matrix4x4 matrix;
		float defaultBaseLine = 0;
		float maxBaseLine = float.MinValue;
		float minBaseLine = float.MaxValue;
		bool isFirst = true;

		for (int i = 0; i < characterCount; i++)
		{
			if (!textInfo.characterInfo[i].isVisible)
				continue;

			int vertexIndex = textInfo.characterInfo[i].vertexIndex;

			int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
			vertices = textInfo.meshInfo[materialIndex].vertices;

			//�����̐^�񒆂̓_�ƕ����̊�ƂȂ�x�[�X���C���̍������擾
			Vector3 offsetToMidBaseline = new Vector2((vertices[vertexIndex + 0].x + vertices[vertexIndex + 2].x) / 2, textInfo.characterInfo[i].baseLine);

			//�����̒����̉������_�ƂȂ�悤�ɒ��_���ړ��i���ꂩ���]�ƈړ��������邽�߁j
			vertices[vertexIndex + 0] += -offsetToMidBaseline;
			vertices[vertexIndex + 1] += -offsetToMidBaseline;
			vertices[vertexIndex + 2] += -offsetToMidBaseline;
			vertices[vertexIndex + 3] += -offsetToMidBaseline;

			//�Ȑ��̌X��(agnle)�̌v�Z
			float x0 = (float)(i + 1) / (characterCount + 1);
			float x1 = x0 + 0.0001f;
			float y0 = vertexCurve.Evaluate(x0);
			float y1 = vertexCurve.Evaluate(x1);
			Vector3 horizontal = new Vector3(1, 0, 0);
			Vector3 tangent = new Vector3(0.0001f, (y1 - y0));
			Vector3 angleDirection = tangent.normalized;
			float angle = Mathf.Acos(Vector3.Dot(horizontal, angleDirection)) * Mathf.Rad2Deg;
			Vector3 cross = Vector3.Cross(horizontal, tangent);
			angle = cross.z > 0 ? angle : 360 - angle;

			//angle��]���������_�ʒu�̌v�Z
			matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, angle));
			vertices[vertexIndex + 0] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 0]);
			vertices[vertexIndex + 1] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 1]);
			vertices[vertexIndex + 2] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 2]);
			vertices[vertexIndex + 3] = matrix.MultiplyPoint3x4(vertices[vertexIndex + 3]);

			//�����Ԃ̌v�Z
			float characterSpace;
			if (isFirst)
			{
				baseline = offsetToMidBaseline;
				defaultBaseLine = baseline.y;
				characterSpace = 0;
				isFirst = false;
			}
			else
			{
				characterSpace = (offsetToMidBaseline - prevOffsetToMidBaseline).magnitude;
			}
			prevOffsetToMidBaseline = offsetToMidBaseline;

			//�����ʒu���v�Z���Ĉړ�
			baseline = baseline + (angleDirection + prevAngleDirection).normalized * characterSpace;
			vertices[vertexIndex + 0] += baseline;
			vertices[vertexIndex + 1] += baseline;
			vertices[vertexIndex + 2] += baseline;
			vertices[vertexIndex + 3] += baseline;

			prevAngleDirection = angleDirection;

			minBaseLine = Mathf.Min(minBaseLine, baseline.y);
			maxBaseLine = Mathf.Max(maxBaseLine, baseline.y);
		}

		//�����̌v�Z
		if (hAlignment != TextAlignment.Left || vAlignment != TextVAlignment.Base)
		{
			float hOffset = 0;
			if (hAlignment == TextAlignment.Center)
				hOffset = (prevOffsetToMidBaseline.x - baseline.x) * 0.5f;
			else if (hAlignment == TextAlignment.Right)
				hOffset = (prevOffsetToMidBaseline.x - baseline.x);

			float vOffset = 0;
			if (vAlignment == TextVAlignment.Bottom)
				vOffset = defaultBaseLine - minBaseLine;
			else if (vAlignment == TextVAlignment.Top)
				vOffset = defaultBaseLine - maxBaseLine;

			Vector3 alignOffset = new Vector3(hOffset, vOffset, 0);

			for (int i = 0; i < characterCount; i++)
			{
				if (!textInfo.characterInfo[i].isVisible)
					continue;

				int vertexIndex = textInfo.characterInfo[i].vertexIndex;
				int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
				vertices = textInfo.meshInfo[materialIndex].vertices;

				vertices[vertexIndex + 0] += alignOffset;
				vertices[vertexIndex + 1] += alignOffset;
				vertices[vertexIndex + 2] += alignOffset;
				vertices[vertexIndex + 3] += alignOffset;
			}
		}

		textComponent.UpdateVertexData();
	}

#if UNITY_EDITOR
	protected virtual void OnValidate()
	{
		UpdateCurveMesh();
	}

	void OnEnable()
	{
		UpdateCurveMesh();
	}

	void OnDisable()
	{
		textComponent.ForceMeshUpdate();
	}
#endif
}