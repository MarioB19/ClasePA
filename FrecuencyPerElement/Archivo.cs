public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {

        //crear arreglo con nums1 y nums2

        int[] arreglomixed = new int[nums1.Length+nums2.Length];

        for(int i =0; i<nums1.Length;i++){
            arreglomixed[i] = nums1[i];
        }
          for(int i =nums1.Length; i<nums2.Length;i++){
            arreglomixed[i] = nums2[i-nums1.Length];
        }

        Array.Sort(arreglomixed);

       

        if(arreglomixed.Length % 2 == 0){


            return (double)(arreglomixed[arreglomixed.Length] + arreglomixed[arreglomixed.Length +1]) /2;
        }
        else{

            double val = (double)(arreglomixed.Length/2);
            val += 0.5;

             return (double) arreglomixed[(int)val];

        }

    }
}



