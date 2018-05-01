Shader "Custom/ScrollWater" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		_ScrollDirX("ScrollDirX", float) = 1
		_ScrollDirY("ScrollDirY", float) = 1
		//_ScrollDir("ScrollDir", float2) = (0,0)
		_ScrollSpeed("ScrollSpeed", float) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float _ScrollDirX;
		float _ScrollDirY;
		float _ScrollSpeed;
		
		UNITY_INSTANCING_CBUFFER_START(Props)
			
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color

			float2 UV = IN.uv_MainTex;
			UV.x += _ScrollDirX * _ScrollSpeed * _Time;
			UV.y += _ScrollDirY * _ScrollSpeed * _Time;
			fixed4 c = tex2D (_MainTex, UV) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
