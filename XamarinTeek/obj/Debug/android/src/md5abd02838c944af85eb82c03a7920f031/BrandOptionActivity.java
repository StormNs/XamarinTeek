package md5abd02838c944af85eb82c03a7920f031;


public class BrandOptionActivity
	extends md5abd02838c944af85eb82c03a7920f031.BaseActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"";
		mono.android.Runtime.register ("XamarinTeek.BrandOptionActivity, XamarinTeek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BrandOptionActivity.class, __md_methods);
	}


	public BrandOptionActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BrandOptionActivity.class)
			mono.android.TypeManager.Activate ("XamarinTeek.BrandOptionActivity, XamarinTeek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}