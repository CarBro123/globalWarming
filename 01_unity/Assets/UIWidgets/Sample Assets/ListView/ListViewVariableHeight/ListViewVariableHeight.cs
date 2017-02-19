using UnityEngine;
using System.Collections;
using UIWidgets;

namespace UIWidgetsSamples {
	
	public class ListViewVariableHeight : ListViewCustomHeight<ListViewVariableHeightComponent,ListViewVariableHeightItemDescription> {
		public int startYear = 1954;
		private int[] years;
		private int ind;
		private int firstYear;
		private int current;
		private AudioSource source;

//		private int temp = 1954;

		void Start () {
			source = GetComponent<AudioSource>();
			ind = GetItemsCount();
			years = new int[ind];
			for (int i = 0; i < GetItemsCount(); i++) {
				years[i] = int.Parse(base.dataSource[i].Name);
			}
			firstYear = years[years.Length-1] - 1;
			current = 0;
			SetScrollValue(GetItemPosition(60),true);
		}

		protected override void SetData(ListViewVariableHeightComponent component, ListViewVariableHeightItemDescription item)
		{
			component.SetData(item);
		}
		
		protected override void HighlightColoring(ListViewVariableHeightComponent component)
		{
			component.Coloring(HighlightedColor, HighlightedBackgroundColor, FadeDuration);
		}
		
		protected override void SelectColoring(ListViewVariableHeightComponent component)
		{
			component.Coloring(SelectedColor, SelectedBackgroundColor, FadeDuration);
		}
		
		protected override void DefaultColoring(ListViewVariableHeightComponent component)
		{
			component.Coloring(DefaultColor, DefaultBackgroundColor, FadeDuration);
		}

/*		void Update () {
			if (Input.GetKeyDown(KeyCode.Keypad7)) {
				temp--;
				OnYearChange(temp);
			}
			if (Input.GetKeyDown(KeyCode.Keypad8)) {
				temp++;
				OnYearChange(temp);
			}
		}*/

		public void OnYearChange (int year) {
			if (year == firstYear) {
				StopAllCoroutines();
				ind = GetItemsCount();
				current = firstYear;
				StartCoroutine(Scroll());
				return;
			}

			if (year > current) {
				for (int i = 0; i < years.Length; i++) {
					if (year == years [i]) {
						StopAllCoroutines();
						ind = i;
						current = year;
						StartCoroutine (Scroll ());
						source.Play();
					}
				}
			} else if (year < current && year > firstYear) {
				StopAllCoroutines();
				ind++;
				current = years[ind];
				StartCoroutine(Scroll());
			}
		}

		IEnumerator Scroll () {
			float t = 0;
			do {
				SetScrollValue(Mathf.Lerp(GetScrollValue(), GetItemPosition(ind), t * 0.1f), true);
				t += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			} while (t < 1);
		}
	}
}