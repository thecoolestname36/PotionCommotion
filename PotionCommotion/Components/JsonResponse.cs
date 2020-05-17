
namespace PotionCommotion.Components {
	public class JsonResponse<T>{
		public int Code { get; set; } = 200;
		public T Result { get; set; }
	}
}