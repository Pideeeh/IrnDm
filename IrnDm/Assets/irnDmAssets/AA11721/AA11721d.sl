#include "include/proctext.h" 
#include "include/noises.h" 
#include "include/gs.h" 
#include "include/stree.h" 
#define MAXJ 5 
displacement
AA11721d(
	float 	plastic_1_0_Ka 	=   0.100;
	float 	plastic_1_0_Kd 	=   1.000;
	float 	plastic_1_0_Ks 	=   0.500;
	float 	plastic_1_0_rgh 	=   0.500;
	string 	spline_2_0_B 	=  "catmull-rom";
	float 	multiply_3_0_A 	=   6.480;
	string 	transform_5_0_FROM 	=  "current";
	string 	transform_5_0_TO 	=  "shader";
	float 	dented_4_0_HGT 	=   2.410;
	float 	dented_4_0_FQ 	=   4.000;
	float 	dented_4_0_OCT 	=   6.000;
	color 	spline_2_0_K1 	= color (   0.310,    1.000,    1.000);
	color 	spline_2_0_K2 	= color (   1.000,    1.000,    1.000);
	color 	spline_2_0_K3 	= color (   0.700,    0.000,    0.000);
	color 	spline_2_0_K4 	= color (   0.800,    0.510,    0.050);
	color 	spline_2_0_K5 	= color (   0.110,    0.150,    0.200);
	color 	spline_2_0_K6 	= color (   1.000,    0.700,    0.300);
	color 	spline_2_0_K7 	= color (   0.000,    0.800,    0.600);
	color 	spline_2_0_K8 	= color (   1.000,    0.990,    0.800);
	string 	spline_2_1_B 	=  "catmull-rom";
	float 	multiply_3_1_A 	=   1.133;
	string 	transform_5_1_FROM 	=  "current";
	string 	transform_5_1_TO 	=  "shader";
	float 	dented_4_1_HGT 	=   4.000;
	float 	dented_4_1_FQ 	=   4.000;
	float 	dented_4_1_OCT 	=   6.000;
	color 	spline_2_1_K1 	= color (   0.750,    1.000,    1.000);
	color 	spline_2_1_K2 	= color (   1.000,    1.000,    1.000);
	color 	spline_2_1_K3 	= color (   0.700,    0.000,    0.000);
	color 	spline_2_1_K4 	= color (   0.800,    0.200,    0.050);
	color 	spline_2_1_K5 	= color (   1.000,    0.500,    0.200);
	color 	spline_2_1_K6 	= color (   1.000,    0.700,    0.300);
	color 	spline_2_1_K7 	= color (   1.000,    0.720,    0.600);
	color 	spline_2_1_K8 	= color (   1.000,    0.900,    0.550);
	string 	spline_2_2_B 	=  "catmull-rom";
	float 	multiply_3_2_A 	=   1.133;
	string 	transform_5_2_FROM 	=  "current";
	string 	transform_5_2_TO 	=  "shader";
	float 	dented_4_2_HGT 	=   4.000;
	float 	dented_4_2_FQ 	=   4.000;
	float 	dented_4_2_OCT 	=   1.110;
	color 	spline_2_2_K1 	= color (   1.000,    0.430,    1.000);
	color 	spline_2_2_K2 	= color (   1.000,    1.000,    1.000);
	color 	spline_2_2_K3 	= color (   0.700,    0.000,    0.000);
	color 	spline_2_2_K4 	= color (   0.800,    0.200,    0.050);
	color 	spline_2_2_K5 	= color (   1.000,    0.500,    0.730);
	color 	spline_2_2_K6 	= color (   1.000,    0.700,    0.300);
	color 	spline_2_2_K7 	= color (   1.000,    0.800,    0.600);
	color 	spline_2_2_K8 	= color (   1.000,    0.900,    0.800);
	color 	plastic_1_0_OP 	= color (   1.000,    0.040,    0.080);
	float 	Displacement_2_3_AMP 	=   1.320;
	string 	transform_5_3_FROM 	=  "current";
	string 	transform_5_3_TO 	=  "shader";
	float 	dented_4_3_HGT 	=   4.000;
	float 	dented_4_3_FQ 	=   4.000;
	float 	dented_4_3_OCT 	=   6.000;
	float	txtscale_1 = 1.0 )

{ 
	color 	plastic_1_0_AMB;
	float 	spline_2_0_C;
	float 	multiply_3_0_B1;
	point 	dented_4_0_PP;
	point 	transform_5_0_PP 	=  P;
	color 	plastic_1_0_DIF;
	float 	spline_2_1_C;
	float 	multiply_3_1_B1;
	point 	dented_4_1_PP;
	point 	transform_5_1_PP 	=  P;
	color 	plastic_1_0_HI;
	float 	spline_2_2_C;
	float 	multiply_3_2_B1;
	point 	dented_4_2_PP;
	point 	transform_5_2_PP 	=  P;
	normal 	plastic_1_0_NN;
	point 	Displacement_2_3_PP 	=  P;
	normal 	Displacement_2_3_DIR 	=  N;
	float 	Displacement_2_3_VAL;
	float 	cube_3_3_A;
	point 	dented_4_3_PP;
	point 	transform_5_3_PP 	=  P;
	point 	transform_5_0_OUT;
	float 	dented_4_0_OUT;
	float 	multiply_3_0_OUT;
	color 	spline_2_0_OUT;
	point 	transform_5_1_OUT;
	float 	dented_4_1_OUT;
	float 	multiply_3_1_OUT;
	color 	spline_2_1_OUT;
	point 	transform_5_2_OUT;
	float 	dented_4_2_OUT;
	float 	multiply_3_2_OUT;
	color 	spline_2_2_OUT;
	point 	transform_5_3_OUT;
	float 	dented_4_3_OUT;
	float 	cube_3_3_OUT;
	normal 	Displacement_2_3_NN;
	vector 	Displacement_2_3_R;
	point 	Displacement_2_3_nuP;
	color 	plastic_1_0_OI;
	color 	plastic_1_0_CI;
	float	i 		= 0;
	float	j 		= 0;
	float	val_1= 0.0, val_2 = 0.0, val_3 = 0.0;
	float	val_4 = 0.0, val_5 = 0.0, val_6 = 0.0;
	float	gs_scale_1=0.0, gs_scale_2=0.0, gs_scale_3=0.0;
	varying point	point_1 = point (0, 0, 0);
	varying point	point_2 = point (0, 0, 0);
	varying point	point_Q = point (0, 0, 0);

	color 	SurfaceColor_0_0_CI;

	/*---------------- In transform_5_0 node: ------------- */	
	transform_5_0_OUT = txtscale_1 * transform(transform_5_0_FROM, transform_5_0_TO, transform_5_0_PP);
	dented_4_0_PP = transform_5_0_OUT;
	
	/*---------------- In dented_4_0 node: ------------- */	
	dented_4_0_OUT = STREE_dented(dented_4_0_PP, dented_4_0_HGT, dented_4_0_FQ, dented_4_0_OCT);
	multiply_3_0_B1 = dented_4_0_OUT;
	
	/*---------------- In multiply_3_0 node: ------------- */	
	multiply_3_0_OUT = multiply_3_0_A * multiply_3_0_B1;
	spline_2_0_C = multiply_3_0_OUT;
	
	/*---------------- In spline_2_0 node: ------------- */	
	spline_2_0_OUT = spline(spline_2_0_B, spline_2_0_C, spline_2_0_K1, spline_2_0_K2, spline_2_0_K3, spline_2_0_K4, spline_2_0_K5, spline_2_0_K6, spline_2_0_K7, spline_2_0_K8);
	plastic_1_0_AMB = spline_2_0_OUT;
	
	/*---------------- In transform_5_1 node: ------------- */	
	transform_5_1_OUT = txtscale_1 * transform(transform_5_1_FROM, transform_5_1_TO, transform_5_1_PP);
	dented_4_1_PP = transform_5_1_OUT;
	
	/*---------------- In dented_4_1 node: ------------- */	
	dented_4_1_OUT = STREE_dented(dented_4_1_PP, dented_4_1_HGT, dented_4_1_FQ, dented_4_1_OCT);
	multiply_3_1_B1 = dented_4_1_OUT;
	
	/*---------------- In multiply_3_1 node: ------------- */	
	multiply_3_1_OUT = multiply_3_1_A * multiply_3_1_B1;
	spline_2_1_C = multiply_3_1_OUT;
	
	/*---------------- In spline_2_1 node: ------------- */	
	spline_2_1_OUT = spline(spline_2_1_B, spline_2_1_C, spline_2_1_K1, spline_2_1_K2, spline_2_1_K3, spline_2_1_K4, spline_2_1_K5, spline_2_1_K6, spline_2_1_K7, spline_2_1_K8);
	plastic_1_0_DIF = spline_2_1_OUT;
	
	/*---------------- In transform_5_2 node: ------------- */	
	transform_5_2_OUT = txtscale_1 * transform(transform_5_2_FROM, transform_5_2_TO, transform_5_2_PP);
	dented_4_2_PP = transform_5_2_OUT;
	
	/*---------------- In dented_4_2 node: ------------- */	
	dented_4_2_OUT = STREE_dented(dented_4_2_PP, dented_4_2_HGT, dented_4_2_FQ, dented_4_2_OCT);
	multiply_3_2_B1 = dented_4_2_OUT;
	
	/*---------------- In multiply_3_2 node: ------------- */	
	multiply_3_2_OUT = multiply_3_2_A * multiply_3_2_B1;
	spline_2_2_C = multiply_3_2_OUT;
	
	/*---------------- In spline_2_2 node: ------------- */	
	spline_2_2_OUT = spline(spline_2_2_B, spline_2_2_C, spline_2_2_K1, spline_2_2_K2, spline_2_2_K3, spline_2_2_K4, spline_2_2_K5, spline_2_2_K6, spline_2_2_K7, spline_2_2_K8);
	plastic_1_0_HI = spline_2_2_OUT;
	
	/*---------------- In transform_5_3 node: ------------- */	
	transform_5_3_OUT = txtscale_1 * transform(transform_5_3_FROM, transform_5_3_TO, transform_5_3_PP);
	dented_4_3_PP = transform_5_3_OUT;
	
	/*---------------- In dented_4_3 node: ------------- */	
	dented_4_3_OUT = STREE_dented(dented_4_3_PP, dented_4_3_HGT, dented_4_3_FQ, dented_4_3_OCT);
	cube_3_3_A = dented_4_3_OUT;
	
	/*---------------- In cube_3_3 node: ------------- */	
	cube_3_3_OUT = (cube_3_3_A * cube_3_3_A * cube_3_3_A);
	Displacement_2_3_VAL = cube_3_3_OUT;
	
	/*---------------- In Displacement_2_3 node: ------------- */	
	if ((Displacement_2_3_VAL != 0) && (Displacement_2_3_AMP != 0)){
		P  = Displacement_2_3_PP + (normalize(Displacement_2_3_DIR) * Displacement_2_3_AMP * Displacement_2_3_VAL);
		N  = calculatenormal(P);
	}
	Displacement_2_3_NN = normalize(N);
	plastic_1_0_NN = Displacement_2_3_NN;
	
	/*---------------- In plastic_1_0 node: ------------- */	
	plastic_1_0_CI = plastic_1_0_OP*(plastic_1_0_AMB*plastic_1_0_Ka*ambient()+(plastic_1_0_AMB*plastic_1_0_Kd*diffuse(faceforward(normalize(plastic_1_0_NN),I))));
	if ( plastic_1_0_Ks > 0 )
	{
	         plastic_1_0_CI += plastic_1_0_HI*plastic_1_0_Ks*specular(faceforward(normalize(plastic_1_0_NN),I),normalize(-I),plastic_1_0_rgh);
	}
	
	SurfaceColor_0_0_CI = plastic_1_0_CI;
	

	Oi = color(1,1,1);
	Ci = SurfaceColor_0_0_CI;
} 
