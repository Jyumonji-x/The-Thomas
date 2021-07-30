Shader "Unlit/hitColor"
{
	Properties
	{
		_Alpha("Alpha value", Range(0,1)) = 0
		_Color("color", Color) = (0,0,0,1)
		_MainTex("Texture", 2D) = "red" {}
	}
		SubShader
	{
		//启用该项确保像素的透明度能被正确输出
		Blend SrcAlpha OneMinusSrcAlpha
		Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog

			float _Alpha;
			float4 _Color;
			sampler2D _Maintex;

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
			float final_alpha = col.a + (1 - col.a) * _Alpha;
			final_alpha *= 1 - step(col.a, 0);

			fixed4 res = fixed4(col.rgb * col.a * (1 - _Alpha) + _Color.rgb * _Alpha, final_alpha);

			// apply fog
			UNITY_APPLY_FOG(i.fogCoord, col);
			return res;
			}
			ENDCG

		}
	}
}
