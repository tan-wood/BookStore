using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9_twoodru8.Model;
using Mission9_twoodru8.Model.ViewModels;

namespace Mission9_twoodru8.Infrastructure
{
	//annotations
	[HtmlTargetElement("div", Attributes = "page-links")]
	//This will be creating a tag helper like asp-action but this one is custom called page-links
	public class PaginationTagHelper : TagHelper
	{
		//dynamically create the page links for us
		private IUrlHelperFactory uhf;

		public PaginationTagHelper(IUrlHelperFactory temp)
		{
			uhf = temp;
		}

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext vc { get; set; }

		//Different than the View Context
		// This is named PageBlah just like in the index for the tag helper it is called page-blah, so c# knows ot put that info here!!
		// it is passing in the info from the model that holds the page info into this and is being received here in pageBlah
		public PageInfo PageLinks { get; set; }
		public string PageAction { get; set; }
		public bool PageClassesEnabled { get; set; } = false;
		public string PageClass { get; set; }
		public string PageClassNormal { get; set; }
		public string PageClassSelected { get; set; }
		// we are overriding the Process method that is contained in the TagHelper class!!!

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			IUrlHelper uh = uhf.GetUrlHelper(vc);

			//building a div and then building a tags within this div
			TagBuilder final = new TagBuilder("div");

			for (int i = 1; i < PageLinks.TotalPages + 1; i++)
			{
				TagBuilder tb = new TagBuilder("a");
				tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
				if (PageClassesEnabled)
				{
					tb.AddCssClass(PageClass);
					tb.AddCssClass(i == PageLinks.CurrentPage
						? PageClassSelected : PageClassNormal);
				}
				tb.InnerHtml.Append(i.ToString());
				final.InnerHtml.AppendHtml(tb);
			}

			output.Content.AppendHtml(final.InnerHtml);


		}
	}
}
