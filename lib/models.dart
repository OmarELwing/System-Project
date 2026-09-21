class SubjectModel {
  final String id;
  final String title;
  final String code;
  final int creditHours;
  final String doctorName;
  final String schedule;
  final String room;
  final String description;

  SubjectModel({
    required this.id,
    required this.title,
    required this.code,
    required this.creditHours,
    required this.doctorName,
    required this.schedule,
    required this.room,
    required this.description,
  });

  factory SubjectModel.fromJson(Map<String, dynamic> json) {
    return SubjectModel(
      id: json['id'] ?? '',
      title: json['title'] ?? '',
      code: json['code'] ?? '',
      creditHours: json['creditHours'] ?? 0,
      doctorName: json['doctorName'] ?? '',
      schedule: json['schedule'] ?? '',
      room: json['room'] ?? '',
      description: json['description'] ?? '',
    );
  }
}

class AssessmentItemModel {
  final String id;
  final String title;
  final String type;
  final String date;
  final double score;
  final double totalScore;
  final String status;

  AssessmentItemModel({
    required this.id,
    required this.title,
    required this.type,
    required this.date,
    required this.score,
    required this.totalScore,
    required this.status,
  });

  factory AssessmentItemModel.fromJson(Map<String, dynamic> json) {
    return AssessmentItemModel(
      id: json['id'] ?? '',
      title: json['title'] ?? '',
      type: json['type'] ?? '',
      date: json['date'] ?? '',
      score: (json['score'] ?? 0).toDouble(),
      totalScore: (json['totalScore'] ?? 0).toDouble(),
      status: json['status'] ?? 'Graded',
    );
  }
}