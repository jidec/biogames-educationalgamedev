var bgColor : Color;    
var blooping : boolean = true;
function Start () {
    StartCoroutine(bgColorShifter());
}
function bgColorShifter()
{
    while (blooping)
    {
        bgColor.r = Random.value / 2; // value is already between 0 and 1
        bgColor.g = Random.value / 2;
        bgColor.b = Random.value / 2;
        bgColor.a = 1.0; // I don't think alpha matters    
        Debug.Log("bgColor: "+bgColor);
        var t: float = 0f;
        var currentColor = Camera.main.backgroundColor;
        while( t < 1.0 )
        {
            Camera.main.backgroundColor = Color.Lerp(currentColor, bgColor, t );
            yield null; // Wait one frame
            t += Time.deltaTime;
        }
    }
}